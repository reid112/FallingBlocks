using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // Keys
    public const string HIGH_SCORE_KEY = "highscore";

    // Scenes
    public const int SCENE_MENU = 0;
    public const int SCENE_PLAY = 1;
    public const int SCENE_LEADERBOARD = 2;
    public const int SCENE_SETTINGS = 3;

    // Labels
    public const string SCORE_LABEL = "Score: ";
    public const string LIVES_LABEL = "Lives: ";

    // Values
    public const int COIN_VALUE = 1;
    public const int RARE_COIN_VALUE = 3;
    public const float SPEED_POWER_UP_MULTIPLIER = 1.1f;

    // Tags
    public const string TAG_FALLING_BLOCK = "Falling Block";
    public const string TAG_COIN = "Coin";
    public const string TAG_RARE_COIN = "Rare Coin";
    public const string TAG_POWER_UP_SPEED = "Speed Power Up";
    public const string TAG_POWER_UP_LIFE = "Life Power Up";
    public const string TAG_SCORES_CONTAINER = "Scores Container";
    public const string TAG_SCORE_INPUT = "Score Input";
    public const string TAG_SCORE_BUTTON = "Score Button";
    public const string TAG_HIGHSCORE_1 = "Highscore 1";
    public const string TAG_HIGHSCORE_2 = "Highscore 2";
    public const string TAG_HIGHSCORE_3 = "Highscore 3";
    public const string TAG_HIGHSCORE_4 = "Highscore 4";
    public const string TAG_HIGHSCORE_5 = "Highscore 5";

    // Animator Variables
    public const string ANIMATOR_ROTATION_DIRECTION = "Direction";

    // Input
    public const string HORIZONTAL = "Horizontal";
    public const int LEFT = -1;
    public const int RIGHT = 1;
}
