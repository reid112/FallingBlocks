using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void onMenuClicked() {
        SceneManager.LoadScene(Constants.SCENE_MENU);
    }

    public void OnPlayClicked() {
        SceneManager.LoadScene(Constants.SCENE_PLAY);
    }

    public void OnLeaderboardClicked() {
        SceneManager.LoadScene(Constants.SCENE_LEADERBOARD);
    }

    public void OnSettingsClicked() {
        SceneManager.LoadScene(Constants.SCENE_SETTINGS);
    }
}
