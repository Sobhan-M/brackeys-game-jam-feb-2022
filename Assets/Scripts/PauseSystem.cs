using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] bool canPause = false;
    [SerializeField] GameObject pauseMenu;
    private GameManager gameManager;
    private bool isPaused = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (canPause && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                gameManager.Resume();
                pauseMenu.SetActive(false);

            }
            else
            {
                isPaused = true;
                gameManager.Pause();
                pauseMenu.SetActive(true);

            }
        }
            
    }



}
