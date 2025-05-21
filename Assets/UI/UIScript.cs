using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public static UIScript Instance;

    public TMP_Text scoreText;

    int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateHealth(TMP_Text player, float health)
    {
        player.text = "P1: " + Mathf.Max(0, health);
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
