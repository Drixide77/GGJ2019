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
        if (score >= 3)
        {
            star1.SetActive(true);
        }
        if (score >= 6)
        {
            star2.SetActive(true);
        }
        if (score >= 9)
        {
            star3.SetActive(true);
        }
    }
}
