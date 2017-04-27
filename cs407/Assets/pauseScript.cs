using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused = false;
    public Button pauseGame;
    public Button resumeGame;
    
    // Use this for initialization
    void Start()

    {
        pauseMenu.SetActive(false);
        pauseGame = GameObject.FindObjectOfType<Button>();
        resumeGame = GameObject.FindObjectOfType<Button>();
       
    }

    // Update is called once per frame
    public void PausePress()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseGame.enabled = true;
        resumeGame.enabled = false;
    }

    public void ResumePress() //responds when user clicks resume game
    {
        pauseMenu.SetActive(false);
        pauseGame.enabled = false;
        resumeGame.enabled = true;
        Time.timeScale = 1;
    }
    public void QuitPress() //responds when user clicks quit game
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void Pause()
    {
        //Application.LoadLevel(1);
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);

        }
        else if (!paused)
        {
            pauseMenu.SetActive(false);
            pauseGame.enabled = true;
            Time.timeScale = 1;

        }
    }

}
