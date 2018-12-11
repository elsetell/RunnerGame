﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour {
    private enum GameStatus { Loading,Defeat,Pause,Play }
    [SerializeField]
    private GameStatus gameState;
    private GameStatus GameState
    {
        get { return gameState; }
        set
        {
            gameState = value;
            switch (gameState)
            {
                case GameStatus.Loading:
                    break;
                case GameStatus.Defeat:
                    break;
                case GameStatus.Pause:
                    break;
                case GameStatus.Play:
                    break;
            }
        }
    }

    private Character player;

    void Start()
    {
        Init();
        GamePreparation();
    }

    private void Init()
    {
        //getMap
        player = GameObject.Find("Player").GetComponent<Character>();
        player.Init();
    }

    void GamePreparation()
    {
        GameState = GameStatus.Loading;
        //createMap
        StartGame();
    }
    public void StartGame()
    {
        PlayGame();
        player.StartFly();
    }

    public void DefeatGame()
    {
        GameState = GameStatus.Defeat;
    }
    public void PauseGame()
    {
        GameState = GameStatus.Pause;
    }
    public void PlayGame()
    {
        GameState = GameStatus.Play;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && GameState == GameStatus.Play)
            GameState = GameStatus.Pause;
    }

}
