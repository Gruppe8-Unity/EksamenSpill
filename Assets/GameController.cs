using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    public UIScript uiScript;
    public PlayerWeaponManager weaponManager;
    public EnemySpawnerScript enemySpawner;
    public GameObject gameOverScreen;

    public int[] upgradeLimits;

    private int currentUpgrade = 0;
    private int levelGap = 5000;
    private bool isGameOver = false;
    private bool newLevel = false;

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

        if (score > levelGap && !newLevel)
        {
            enemySpawner.cooldown = Mathf.Max(0.1f, enemySpawner.cooldown - 0.7f);
            enemySpawner.bossSpawnerTimer = Mathf.Max(2f, enemySpawner.bossSpawnerTimer - 8f);
            newLevel = true;
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
