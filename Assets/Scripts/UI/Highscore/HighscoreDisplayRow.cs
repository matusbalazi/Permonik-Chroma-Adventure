using TMPro;
using UnityEngine;

public class HighscoreDisplayRow : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public void DisplayHighScore(int score)
    {
        scoreText.text = string.Format("{0:000000}", score);
    }
    public void HideEntryDisplay()
    {
        scoreText.text = "";
    }
}