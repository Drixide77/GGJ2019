﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [Header("GameObject and Script References")]
    public Fader fader;
    public UIController uiController;

    public Text nextWaveText;
    public Text timerText;
    public Text roundTimer;

    public RigidBodyMovement player1;
    [HideInInspector]
    public bool player1Active = false;
    int player1Score = 0;

    public RigidBodyMovement player2;
    [HideInInspector]
    public bool player2Active = false;
    int player2Score = 0;

    public RigidBodyMovement player3;
    [HideInInspector]
    public bool player3Active = false;
    int player3Score = 0;

    public RigidBodyMovement player4;
    [HideInInspector]
    public bool player4Active = false;
    int player4Score = 0;

    [Header("Adjustable Values")]
    public int initialCountdown = 3;
    public int numberOfRounds = 5;

    int currentTime = 20;

    int[] roundTimers;

    bool gameRunning = false;
    int roundNumber = 0;

    int[] scores = new int[4];

    Action nextRoundCallback;

    // Start is called before the first frame update
    void Start() {
        GenerateRoundTimes();
        nextRoundCallback = () =>
        {
            ++roundNumber;
            roundTimer.text = "Round: " + (roundNumber + 1);
            if (roundNumber >= numberOfRounds)
            {
                FinishGame(true, -1);
                return;
            }
            currentTime = this.roundTimers[roundNumber];
        };

        nextWaveText.text = "";
        timerText.text = "READY?";
        roundTimer.text = "";
        int[] roundTimers = new int[numberOfRounds];

        Unfade();
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        // Check player score
        if (player1Active && player1.score > player1Score)
        {
            uiController.SetScoreForPlayer(player1.score, 1);
            if (player1.score == 3)
            {
                FinishGame(false, 1);
            }
        }
        if (player2Active && player2.score > player2Score)
        {
            uiController.SetScoreForPlayer(player2.score, 2);
            if (player2.score == 3)
            {
                FinishGame(false, 2);
            }
        }
        if (player3Active && player3.score > player3Score)
        {
            uiController.SetScoreForPlayer(player3.score, 3);
            if (player3.score == 3)
            {
                FinishGame(false, 3);
            }
        }
        if (player4Active && player4.score > player4Score)
        {
            uiController.SetScoreForPlayer(player4.score, 4);
            if (player4.score == 3)
            {
                FinishGame(false, 4);
            }
        }
    }

    void Unfade()
    {
        if (!fader.gameObject.activeInHierarchy) fader.gameObject.SetActive(true);
        fader.DoFade(0.0f, 0.2f, (finish) => { });
    }

    void GenerateRoundTimes()
    {
        roundTimers = new int[numberOfRounds];

        // TODO - Proper generation
        for (int i = 0; i < numberOfRounds; ++i)
        {
            System.Random rnd = new System.Random();
            roundTimers[i] = rnd.Next(15, 20);
        }

        currentTime = roundTimers[0];
    }

    void FinishGame(bool timeOut, int playerId )
    {
        // TODO 
        player1.pause = true;
        player2.pause = true;
        player3.pause = true;
        player4.pause = true;

    }

    void StartTimer()
    {
        StartCoroutine(StartTimerCoroutine(() => {
            gameRunning = true;
        }));
    }

    IEnumerator StartTimerCoroutine(Action callback)
    {
        int countdown = initialCountdown;
        yield return new WaitForSeconds(2.0f);
        nextWaveText.text = "Game begins in";
        timerText.text = ""+countdown;
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1.0f);
            --countdown;
            if (countdown <= 0)
            {
                timerText.text = "GO!";
                roundTimer.text = "Round: " + (roundNumber + 1);
            }
            else timerText.text = "" + countdown;
            // TODO - Play beep sound for timer
        }

        callback();
        yield return new WaitForSeconds(0.5f);
        nextWaveText.text = "Next Wave";
        timerText.text = "" + currentTime;

        StartCoroutine(RoundTimerCoroutine());
    }

    IEnumerator RoundTimerCoroutine()
    {
        while (gameRunning)
        {
            yield return new WaitForSeconds(1.0f);
            --currentTime;
            timerText.text = currentTime+"";
            if (currentTime <= 0) {
                timerText.text = "WAVE!";
                nextRoundCallback();
            }
        }
    }
}
