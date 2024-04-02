using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    public GameState State;
    public static Action<GameState> OnGameStateChange;

    private void Start()
    {
        instance = this;
    }


    public void ChangeGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.PlAYING:
                break;
            case GameState.WIN:
                break;
            case GameState.LOSE:
                break;
            case GameState.PAUSE:
                break;
        }

        OnGameStateChange?.Invoke(newState);
    }

}

public enum GameState
{
    PAUSE,
    LOSE,
    WIN,
    PlAYING
}
