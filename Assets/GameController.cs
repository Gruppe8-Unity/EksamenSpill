using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player playerOne;
    public Player playerTwo;
    public UIScript uiScript;
    public PlayerWeaponManager playerOneWeapon;
    public PlayerWeaponManager playerTwoWeapon;
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

        if (!isGameOver && (playerOne.health <= 0 && playerTwo.health <= 0))
        {
            GameOverEnable();
        }

        if (currentUpgrade < upgradeLimits.Length && score >= upgradeLimits[currentUpgrade])
        {
            playerOneWeapon.UpgradeWeapon();
            playerTwoWeapon.UpgradeWeapon();    
            currentUpgrade++;
        }

        if (score > levelGap && !newLevel)
        {
            enemySpawner.cooldown = Mathf.Max(0.1f, enemySpawner.cooldown - 0.75f);
            enemySpawner.bossSpawnerTimer = Mathf.Max(2f, enemySpawner.bossSpawnerTimer - 9f);
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
        SceneManager.LoadScene("MenuScene");
    }
}
