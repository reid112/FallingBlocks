using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void onMenuClicked() {
        SceneManager.LoadScene(0);
    }

    public void OnLeaderboardClicked() {
        SceneManager.LoadScene(1);
    }

    public void OnSettingsClicked() {
        SceneManager.LoadScene(1);
    }

    public void OnPlayClicked() {
        SceneManager.LoadScene(1);
    }
}
