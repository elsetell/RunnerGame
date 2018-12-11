using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlUI : MonoBehaviour {
    [SerializeField]
    private GameObject defeatUI;
    [SerializeField]
    private GameObject pauseUI;

    public void DefeatUI()
    {
        defeatUI.SetActive(true);
    }
    public void PauseUI()
    {
        pauseUI.SetActive(true);
    }
    public void PlayUI()
    {
        pauseUI.SetActive(false);
    }
}
