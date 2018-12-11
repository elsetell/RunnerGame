using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour {
    private enum GameStatus { Loading, Defeat, Pause, Play }
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
                    //the game is too fast =)
                    break;
                case GameStatus.Defeat:
                    Time.timeScale = 0;
                    gameUI.DefeatUI();
                    break;
                case GameStatus.Pause:
                    Time.timeScale = 0;
                    gameUI.PauseUI();
                    break;
                case GameStatus.Play:
                    Time.timeScale = 1;
                    gameUI.PlayUI();
                    break;
            }
        }
    }

    private GameControlUI gameUI;
    private Character player;
    private MapControl mapControl;

    void Start()
    {
        Init();
        GamePreparation();
    }

    private void Init()
    {
        player = GameObject.Find("Player").GetComponent<Character>();
        player.Init();
        mapControl = GameObject.Find("MapControl").GetComponent<MapControl>();
        gameUI = GetComponent<GameControlUI>();
    }

    void GamePreparation()
    {
        GameState = GameStatus.Loading;
        mapControl.CreateMap();
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
