using System.Collections.Generic;
using UnityEngine;

public class HighscoreDisplayManager : MonoBehaviour
{
    [SerializeField] private HighscoreDisplayRow[] highScoreDisplayArray;
    [SerializeField] private GameObject controller;
    private List<int> score;

    private void OnEnable()
    {
        var component = controller.GetComponent<XMLHighscoreManager>();
        score = component.Highscores;
        ShowScore();
    }

    public void ShowScore()
    {
        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < score.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(score[i]);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }
}