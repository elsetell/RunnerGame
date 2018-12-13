using UnityEngine;
using UnityEngine.UI;

public class CharacterUIController : MonoBehaviour {
    [SerializeField]
    private Text score_text;

    public void RefreshScoreUI(int distance, int score)
    {
        score_text.text = "Score: " + score + '\n' + "Distance: " + distance + "m";
    }
}
