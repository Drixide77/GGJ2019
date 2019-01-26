using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRespawner : MonoBehaviour
{

    public GameObject[] tier1maps;
    public GameObject[] tier2maps;
    public GameObject[] tier3maps;
    private GameObject currentMap;

    float counter = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0.0f) {
            ReMap(1);
            counter = 5.0f;
        }
    }

    public void ReMap(int wave) {
        if (currentMap != null) Destroy(currentMap);
        GameObject[] maps = new GameObject[0] ;
        switch (wave) {
            case 1:
                maps = tier1maps;
                break;
            case 2:
                maps = tier2maps;
                break;
            case 3:
                maps = tier3maps;
                break;
        }
        int randomMap = Random.Range(0, maps.Length);
        GameObject map = maps[randomMap];
        currentMap = map;
        MapRotableCheck mrc = map.GetComponent<MapRotableCheck>();
        GameObject instantiatedMap = Instantiate(map, map.transform.position, map.transform.rotation);
        currentMap = instantiatedMap;
        if (mrc != null && mrc.IsRotable)
        {
            Debug.Log("Here");
            float initialRotation = Random.Range(0.0f, 360.0f);
            instantiatedMap.transform.eulerAngles = new Vector3(0.0f, initialRotation, 0.0f);
        }

    }
}
