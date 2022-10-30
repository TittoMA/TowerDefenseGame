using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public float timeRemaining = 60.0f;
    public GameObject gameOver;
    public GameObject gameWin;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameIsPaused){

            if(timeRemaining > 0){ 
                timeRemaining -= Time.deltaTime;
                timeText.text = timeRemaining.ToString("0.00");
            }
        }

        if(timeRemaining <= 0) {
            Pause();
            gameWin.SetActive(true);
        }
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
