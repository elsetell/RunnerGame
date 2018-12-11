using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private ControlGame controlGame;
    private CharacterInputController engine;
    private CharacterUIController ui_controller;
    private Vector3 startPos;

    //scoreInfo
    private int distance;
    private int scoreForBonus;
    private int score;

    public delegate void CreatePlatform();
    public CreatePlatform createPlatform;

    //bonus var
    [SerializeField]
    private GameObject shield;
    private bool invul;
    private Coroutine invulСountdown;

    public void Init()
    {
        engine = GetComponent<CharacterInputController>();
        engine.refreshDitance = new CharacterInputController.RefreshDistance(RefreshDistance);
        ui_controller = GetComponent<CharacterUIController>();
        controlGame = GameObject.Find("GameControl").GetComponent<ControlGame>();
        startPos = transform.position;

        MapControl mapControl = GameObject.Find("MapControl").GetComponent<MapControl>();
        createPlatform = mapControl.CreatePlatform;
    }

    public void StartFly()
    {
        engine.StartEngine();
    }

    void RefreshDistance()
    {
        distance = (int)Vector3.Distance(transform.position, startPos);
        RefreshScore();
    }
    void RefreshScore()
    {
        score = scoreForBonus + distance;
        ui_controller.RefreshScoreUI(distance, score);
    }

    public void DestroyCharacter()
    {
        if (!invul)
        {
            engine.StopEngine();
            controlGame.DefeatGame();
        }
    }

    public void TakeBonus(int bonus, float sec)
    {
        scoreForBonus += bonus;
        RefreshScore();
        invulСountdown = StartCoroutine(Invulnerability(sec));
    }

    IEnumerator Invulnerability(float sec)
    {
        invul = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(sec);
        shield.SetActive(false);
        invul = false;
    }
}
