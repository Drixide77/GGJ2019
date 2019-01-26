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

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // TODO
        gameController.player1Active = true;
        gameController.player2Active = false;
        gameController.player3Active = false;
        gameController.player4Active = false;

        gameController.uiController.SetPlayerEnabled(1, true);
        gameController.uiController.SetPlayerEnabled(2, false);
        gameController.uiController.SetPlayerEnabled(3, false);
        gameController.uiController.SetPlayerEnabled(4, false);

        gameController.player1.gameObject.SetActive(true);
        gameController.player2.gameObject.SetActive(false);
        gameController.player3.gameObject.SetActive(false);
        gameController.player4.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
