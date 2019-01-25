using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTableManager : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;


    // Start is called before the first frame update
    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        if (score >= 1)
        {
            star1.SetActive(true);
        }
        else if (score >= 2)
        {
            star2.SetActive(true);
        }
        else if (score >= 3)
        {
            star3.SetActive(true);
        }
    }
}
