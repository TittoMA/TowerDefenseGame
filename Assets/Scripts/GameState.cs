using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Play() 
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void PlayAgain()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
