using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public ScoreTableManager topLeft;
    public ScoreTableManager topRight;
    public ScoreTableManager bottomLeft;
    public ScoreTableManager bottomRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoreForPlayer(int score, int player)
    {
        switch (player)
        {
            case 1:
                topLeft.SetScore(score);
                break;
            case 2:
                topRight.SetScore(score);
                break;
            case 3:
                bottomLeft.SetScore(score);
                break;
            case 4:
                bottomRight.SetScore(score);
                break;
        }
    }
}
