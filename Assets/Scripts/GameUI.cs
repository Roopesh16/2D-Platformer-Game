using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject healthBar;

    private int score = 0;
    private Image[] hearts;

    private void Start()
    {
        DisplayScore();
        hearts = healthBar.GetComponentsInChildren<Image>();
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = "SCORE : " + score;
    }

    public void UpdateHealth(int index)
    {
        if(index < 0)
        {
            return;
        }

        hearts[index].enabled = false;
    }
}
