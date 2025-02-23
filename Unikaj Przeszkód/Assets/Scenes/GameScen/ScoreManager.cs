using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Przypisz ten element w Inspectorze
    private int score = 0;

    public void AddPoint()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Punkty: " + score;
        }
    }
}
