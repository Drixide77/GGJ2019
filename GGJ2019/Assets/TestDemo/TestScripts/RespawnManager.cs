using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject[] players;
    private List<GameObject> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child.gameObject);
        }
        for (int i = 0; i < 4; ++i)
        {
            int spawnPoint = Random.Range(0, spawnPoints.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
