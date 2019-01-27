using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinScreenController : MonoBehaviour
{
    public Text player1;
    public Text player2;
    public Text player3;
    public Text player4;

    public Image crab1;
    public Image crab2;
    public Image crab3;
    public Image crab4;

    public GameController gameController;

    int minimumPlayers = 1;
    int joinedPlayers = 0;
    public GameObject pressStartPromt;

    // Start is called before the first frame update
    void Start()
    {
        // TODO
        gameController.player1Active = false;
        gameController.player2Active = false;
        gameController.player3Active = false;
        gameController.player4Active = false;

        gameController.uiController.SetPlayerEnabled(1, false);
        gameController.uiController.SetPlayerEnabled(2, false);
        gameController.uiController.SetPlayerEnabled(3, false);
        gameController.uiController.SetPlayerEnabled(4, false);

        gameController.player1.gameObject.SetActive(false);
        gameController.player2.gameObject.SetActive(false);
        gameController.player3.gameObject.SetActive(false);
        gameController.player4.gameObject.SetActive(false);

        pressStartPromt.SetActive(false);

        // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1_1") && !gameController.player1Active) {
            gameController.player1Active = true;
            gameController.uiController.SetPlayerEnabled(1, true);
            gameController.player1.gameObject.SetActive(true);
            crab1.gameObject.SetActive(true);
            ++joinedPlayers;
        }

        if (Input.GetButtonDown("Fire1_2") && !gameController.player2Active)
        {
            gameController.player2Active = true;
            gameController.uiController.SetPlayerEnabled(2, true);
            gameController.player2.gameObject.SetActive(true);
            crab2.gameObject.SetActive(true);
            ++joinedPlayers;
        }

        if (Input.GetButtonDown("Fire1_3") && !gameController.player3Active)
        {
            gameController.player3Active = true;
            gameController.uiController.SetPlayerEnabled(3, true);
            gameController.player3.gameObject.SetActive(true);
            crab3.gameObject.SetActive(true);
            ++joinedPlayers;
        }

        if (Input.GetButtonDown("Fire1_4") && !gameController.player4Active)
        {
            gameController.player4Active = true;
            gameController.uiController.SetPlayerEnabled(4, true);
            gameController.player4.gameObject.SetActive(true);
            crab4.gameObject.SetActive(true);
            ++joinedPlayers;
        }

        if (joinedPlayers >= minimumPlayers && Input.GetButtonDown("Start"))
        {
            gameController.StartTimer();
            gameObject.SetActive(false);
        }

        if (!pressStartPromt.activeInHierarchy && joinedPlayers >= minimumPlayers)
        {
            pressStartPromt.SetActive(true);
        }
    }
}
