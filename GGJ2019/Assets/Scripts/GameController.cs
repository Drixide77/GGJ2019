using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [Header("GameObject and Script References")]
    public Fader fader;

    public Text nextWaveText;
    public Text timerText;
    public Text roundTimer;

    // public player1;
    // public player2;
    // public player3;
    // public player4;

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
                FinishGame(true);
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

    void FinishGame(bool timeOut)
    {
        // TODO 

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
