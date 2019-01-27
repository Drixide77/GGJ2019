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
        FillSpawnPointsList();
    }

    void FillSpawnPointsList()
    {
        spawnPoints = new List<GameObject>();
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {      
        for (int i = 0; i < 4; ++i)
        {
            int spawnPoint = Random.Range(0, spawnPoints.Count);
            players[i].transform.position =  spawnPoints[spawnPoint].transform.position;
            float initialRotation = Random.Range(0.0f, 360.0f);
            players[i].transform.eulerAngles = new Vector3(0.0f, initialRotation, 0.0f);
            spawnPoints.RemoveAt(spawnPoint);
            if (spawnPoints.Count <= 0)
            {
                FillSpawnPointsList();
            }
        }
    }
}
