using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    public GameState State;
    [SerializeField]private bool _gameStart;
    public bool GameStart
    {
        get { return _gameStart; }
    }
    //public static Action<GameState> OnGameStateChange;
    public PlayerController player;
    public PlayerController playerPrefab;

    private void Awake()
    {
        instance = this;
        ChangeGameState(GameState.START);
    }

    
    public void ChangeGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.START:
                Starting();
                break;
            case GameState.PLAYING:
                Playing();
                break;
            case GameState.WIN:
                Complete(true);
                break;
            case GameState.LOSE:
                Complete(false);
                break;
            case GameState.PAUSE:
                Pause();
                break;
        }


        Debug.Log(newState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeGameState(GameState.LOSE);
        }
    }

    private void Starting()
    {
        player = Instantiate(playerPrefab);
        CameraManager.instance.Follow(player);
        _gameStart = true;
    }
    private void Playing()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    private void Complete(bool _bool)
    {
        _gameStart = false;

        if (_bool)
        {
            // WIN!!
        }

        if (!_bool)
        {
            // LOSE!!
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

}


public enum GameState
{
    START,
    PAUSE,
    LOSE,
    WIN,
    PLAYING
}
