using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    public UIScript uiScript;
    public PlayerWeaponManager weaponManager;
    public GameObject gameOverScreen;

    public int[] upgradeLimits;

    private int currentUpgrade = 0;
    private bool isGameOver = false;

    private void Update()
    {
        int score = uiScript.GetScore();

        if (!isGameOver && player.health <= 0)
        {
            GameOverEnable();
        }

        if (currentUpgrade < upgradeLimits.Length && score >= upgradeLimits[currentUpgrade])
        {
            weaponManager.UpgradeWeapon();
            currentUpgrade++;
        }

    }

    private void GameOverEnable()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
