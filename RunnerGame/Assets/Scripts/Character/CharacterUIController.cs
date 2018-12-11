using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIController : MonoBehaviour {
    private Text score_text;

    private void Start()
    {
        score_text = GameObject.Find("Canvas/DistanceText").GetComponent<Text>();
    }

    public void RefreshScoreUI(int distance, int score)
    {
        score_text.text = "Score: " + score + '\n' + "Distance: " + distance + "m";
    }
}
