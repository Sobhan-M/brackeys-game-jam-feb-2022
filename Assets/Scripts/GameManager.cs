using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
