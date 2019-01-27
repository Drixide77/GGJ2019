using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [Header("GameObject and Script References")]
    public Fader fader;
    public UIController uiController;
    public RespawnManager respawnManager;
    public MapRespawner mapRespawner;
    public GameObject resultCanvas;
    public GameObject waveObject;
    public Vector3 waveStartingPoint;
    public Vector3 waveEndPoint;

    public Text nextWaveText;
    public Text timerText;
    public Text roundTimer;
    public Text winnerText;

    public Image winnerPanel;

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

    public Color colorPlayer1;
    public Color colorPlayer2;
    public Color colorPlayer3;
    public Color colorPlayer4;

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
                System.Random rnd = new System.Random();
                currentTime = rnd.Next(5, 15);
            }
            else currentTime = this.roundTimers[roundNumber];
        };

        nextWaveText.text = "";
        timerText.text = "READY?";
        roundTimer.text = "";
        int[] roundTimers = new int[numberOfRounds];

        Unfade();
        // StartTimer();
    }

    void DoWave()
    {
        StartCoroutine(DoWaveCoroutine());
    }

    IEnumerator DoWaveCoroutine()
    {
        float duration = 4.0f;
        float currentTime = 0.0f;
        bool spawnTriggered = false;

        while (currentTime < duration)
        {
            waveObject.transform.position = new Vector3(Mathf.Lerp(waveStartingPoint.x, waveEndPoint.x, currentTime / duration),
                Mathf.Lerp(waveStartingPoint.y, waveEndPoint.y, currentTime / duration), Mathf.Lerp(waveStartingPoint.z, waveEndPoint.z, currentTime / duration));

            if (!spawnTriggered && (currentTime / duration) >= 0.5f)
            {
                spawnTriggered = true;
                mapRespawner.ReMap();
                respawnManager.Respawn();
            }

            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check player score
        if (player1Active && player1.score > player1Score)
        {
            player1Score = player1.score;
            if (player1.score % 3 == 0)
            {
                player1.CallCleanShells();
            }
            uiController.SetScoreForPlayer(player1.score, 1);
            if (player1.score == 9)
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

        if (!gameRunning && resultCanvas.activeInHierarchy)
        {
            if (Input.GetButtonDown("Fire1_1") || Input.GetButtonDown("Fire1_2") || Input.GetButtonDown("Fire1_3") || Input.GetButtonDown("Fire1_4"))
            {
                SceneManager.LoadScene("Menu");
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
        System.Random rnd = new System.Random();
        for (int i = 0; i < numberOfRounds; ++i)
        {
            if (i <= 0) roundTimers[i] = 20;
            else if (i == 1) roundTimers[i] = rnd.Next(10, 20);
            else if (i == 2) roundTimers[i] = rnd.Next(10, 15);
            else if (i >= 3) roundTimers[i] = rnd.Next(5, 15);
        }

        currentTime = roundTimers[0];
    }

    void FinishGame(bool timeOut, int playerId )
    {
        gameRunning = false;
        nextWaveText.text = "";
        timerText.text = "FINISH!";

        // TODO 
        player1.pause = true;
        player2.pause = true;
        player3.pause = true;
        player4.pause = true;

        resultCanvas.SetActive(true);
        switch (playerId)
        {
            case 1:
                winnerText.text = "Red crab got a new home";
                winnerPanel.color = colorPlayer1;
                break;
            case 2:
                winnerText.text = "Blue crab got a new home";
                winnerPanel.color = colorPlayer2;
                break;
            case 3:
                winnerText.text = "Green crab got a new home";
                winnerPanel.color = colorPlayer3;
                break;
            case 4:
                winnerText.text = "Purple crab got a new home";
                winnerPanel.color = colorPlayer4;
                break;
        }
    }

    public void StartTimer()
    {
        StartCoroutine(StartTimerCoroutine(() => {
            gameRunning = true;
            player1.pause = false;
            player2.pause = false;
            player3.pause = false;
            player4.pause = false;
        }));
    }

    IEnumerator StartTimerCoroutine(Action callback)
    {
        int countdown = initialCountdown;
        yield return new WaitForSeconds(2.5f);

        timerText.text = "GO!";
        roundTimer.text = "Round: " + (roundNumber + 1);
        /*
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
        */

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
                this.DoWave();
                nextRoundCallback();
                yield return new WaitForSeconds(3.0f);
            }
        }
    }
}
