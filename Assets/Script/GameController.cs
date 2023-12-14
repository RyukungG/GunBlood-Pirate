using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool playing {get; private set;}
    private bool starting = false;
    public GameObject gameOverPanel;
    public int countdownTime;
    public Text countdownDisplay;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playing = false;
    }

     void Update()
    {
        if(!starting && Input.GetKeyDown(KeyCode.Space))
        {
            gameOverPanel.SetActive(false);
            StartCoroutine(CountdownToStart());
        }
    }

    public void beginGame()
    {
        playing = true;
    }

    public void endGame()
    {
        playing = false;
        gameOverPanel.SetActive(true);
    }

    IEnumerator CountdownToStart()
    {
        countdownDisplay.gameObject.SetActive(true);
        int tempTime = countdownTime;
        starting = true;
        
        while(tempTime > 0)
        {
            countdownDisplay.text = tempTime.ToString();
            yield return new WaitForSeconds(1f);
            tempTime--;
        }

        countdownDisplay.text = "Shoot!!";

        //GameController.Begin();

        yield return new WaitForSeconds(0.5f);
        countdownDisplay.gameObject.SetActive(false);
        
        starting = false;

        beginGame();
    }
}
