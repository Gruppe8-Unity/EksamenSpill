using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject tutorialScene;

    public void EnterTutorial()
    {
        tutorialScene.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        tutorialScene.SetActive(false);
    }
}
