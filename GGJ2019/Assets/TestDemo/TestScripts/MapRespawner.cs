using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRespawner : MonoBehaviour
{

    public GameObject[] maps;
    bool renew = false;
    private List<GameObject> availableMaps;
    private GameObject currentMap;

    // Start is called before the first frame update
    void Start()
    {
        availableMaps = new List<GameObject>(maps);
        ReMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReMap() {
        if (currentMap != null) Destroy(currentMap);      
        int randomMap = Random.Range(0, (availableMaps.Count-1));
        GameObject map = availableMaps[randomMap];
        currentMap = map;
        MapRotableCheck mrc = map.GetComponent<MapRotableCheck>();
        GameObject instantiatedMap = Instantiate(map, map.transform.position, map.transform.rotation);
        currentMap = instantiatedMap;
        if (mrc != null && mrc.IsRotable)
        {
            float initialRotation = Random.Range(0.0f, 360.0f);
            instantiatedMap.transform.eulerAngles = new Vector3(0.0f, initialRotation, 0.0f);
        }
        if (!renew) {
            availableMaps.RemoveAt(randomMap);
            if (availableMaps.Count == 1) renew = true;
        }
        else
        {
            renew = false;
            availableMaps = new List<GameObject>(maps);
        }
    }
}
