using UnityEngine;
using Models;
using Proyecto26;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

	private readonly string basePath = "https://fallingblocksapi.rjreid.ca";
    private readonly string leaderboardsPath = "/api/leaderboards";
	private RequestHelper currentRequest;

    private void Start() {
        GetScores();
    }

	private void GetScores(){
		RestClient.GetArray<Score>(basePath + leaderboardsPath).Then(res => {
			showScores(res);
		}).Catch(err => print("Error" + err.Message));
	}

    private void showScores(Score[] scores) {
        for (int i = 0; i < scores.Length; i++) {
            setScore(GameObject.FindGameObjectWithTag(getTag(i)).GetComponent<Text>(), scores[i].name, scores[i].score);
        } 
    }

    private void setScore(Text text, string name, string score) {
        text.text = name + ": " + score;
    }

    private string getTag(int i) {
        switch (i) {
            case 0: return Constants.TAG_HIGHSCORE_1;
            case 1: return Constants.TAG_HIGHSCORE_2;
            case 2: return Constants.TAG_HIGHSCORE_3;
            case 3: return Constants.TAG_HIGHSCORE_4;
            case 4: return Constants.TAG_HIGHSCORE_5;
        }

        return Constants.TAG_HIGHSCORE_1;
    }




    public void onSaveScoreClicked() {
        InputField input = FindObjectOfType<InputField>();
        Button button = GameObject.FindGameObjectWithTag(Constants.TAG_SCORE_BUTTON).GetComponent<Button>();
        string highscore = PlayerPrefs.GetInt(Constants.HIGH_SCORE_KEY, 0).ToString();

        Post(input.text, highscore);

        input.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }

	private void Post(string name, string score){
		currentRequest = new RequestHelper {
			Uri = basePath + leaderboardsPath,
			Body = new Score {
				name = name,
				score = score
			}
		};
		RestClient.Post<Score>(currentRequest)
		.Then(res => {
			print("Success" + JsonUtility.ToJson(res, true));
		})
		.Catch(err => print("Error" + err.Message));
	}
}