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
                    Debug.Log("loading");
                    break;
                case GameStatus.Defeat:
                    Debug.Log("Defeat");
                    break;
                case GameStatus.Pause:
                    Debug.Log("Pause");
                    break;
                case GameStatus.Play:
                    Debug.Log("Play");
                    break;
            }
        }
    }

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
