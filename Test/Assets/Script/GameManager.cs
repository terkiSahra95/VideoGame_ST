using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manage our game
public class GameManager : MonoBehaviour
{
    public Player player;
    public Text PointText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        //we wait the play button need to be click
        Pause();
    }

    public void Play()
    {
        score = 0;
        PointText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

       
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    //When we touch pipes our ground
    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }


    public void Pause()
    {
        //setting our time scale to 0, it's freezing the game
        Time.timeScale = 0f;
        player.enabled = false;
    }

    //Increase our score whan we don't touch pipes
    public void IncreaseScore()
    {
        score++;
        PointText.text = score.ToString();
    }

}


