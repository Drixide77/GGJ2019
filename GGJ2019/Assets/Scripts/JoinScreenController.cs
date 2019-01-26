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
        gameController.player2Active = true;
        gameController.player3Active = true;
        gameController.player4Active = true;

        gameController.uiController.SetPlayerEnabled(1, true);
        gameController.uiController.SetPlayerEnabled(2, true);
        gameController.uiController.SetPlayerEnabled(3, true);
        gameController.uiController.SetPlayerEnabled(4, true);

        gameController.player1.gameObject.SetActive(true);
        gameController.player2.gameObject.SetActive(true);
        gameController.player3.gameObject.SetActive(true);
        gameController.player4.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
