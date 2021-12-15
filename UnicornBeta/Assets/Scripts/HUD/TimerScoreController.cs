using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScoreController : MonoBehaviour
{
    public float remainingTime = 60f;
    public GameObject winText;
    public GameObject restartButton;
    public GameObject loseText;
    public Text timerText;
    public Text scoreText;

    //public PlayerEventController playerEventController;

    int playerScore = 0;

    public static bool GameIsRunning = true;

    private void Update()
    {
       if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (PlayerEventController.isDead == true)
            {
                remainingTime -= Time.deltaTime;
                GameIsRunning = false;
                loseText.SetActive(true);
                restartButton.SetActive(true);
            }
        }

       if(remainingTime <= 0 && GameIsRunning ==true)
        {
            GameIsRunning = false;
            winText.SetActive(true);
            restartButton.SetActive(true);

            //won game, present restart button, present score
        }

        timerText.text = remainingTime + "s";
        scoreText.text = playerScore.ToString();
    }
}
