using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var director = GetComponent<PlayableDirector>();
        director.stopped += OnTimeLineStopped;   
    }

    void OnTimeLineStopped(PlayableDirector pd)
    {
        SceneManager.LoadScene("MenuScene");
    }

}
