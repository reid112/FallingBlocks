using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // Keys
    public const string HIGH_SCORE_KEY = "highscore";

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

    // Animator Variables
    public const string ANIMATOR_ROTATION_DIRECTION = "Direction";

    // Input
    public const string HORIZONTAL = "Horizontal";
    public const int LEFT = -1;
    public const int RIGHT = 1;
}
