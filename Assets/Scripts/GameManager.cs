using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    [SerializeField] bool canPause = false;
    private bool isPaused = false;

    private Scene currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        Time.timeScale = 1;
        if (canPause)
        {
            pauseMenu.gameObject.SetActive(false);
        }   
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

    public void LoadWin()
    {
        SceneManager.LoadScene("Win Scene");
    }

    public void LoadLose()
    {
        SceneManager.LoadScene("Lose Scene");
    }

    public void Quit()
    {
        Application.Quit(); 
    }

    public void Pause()
    {
        if (canPause)
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.gameObject.SetActive(isPaused);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
