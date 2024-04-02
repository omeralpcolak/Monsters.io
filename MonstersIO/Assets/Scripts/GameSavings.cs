using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSavings : ScriptableObject
{
    public static int Coin
    {
        get => PlayerPrefs.GetInt("Coin", 1);
        set => PlayerPrefs.SetInt("Coin", value);
    }

    public static int Diamond
    {
        get => PlayerPrefs.GetInt("Diamond", 1);
        set => PlayerPrefs.SetInt("Diamond", value);
    }
}
