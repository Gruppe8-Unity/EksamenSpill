using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public static UIScript Instance;

    public TMP_Text healthText;
    public TMP_Text scoreText;
    public TMP_Text levelText;

    int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateHealth(float health)
    {
        healthText.text = "P1: " + Mathf.Max(0, health);
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "SCORE: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
