using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRespawner : MonoBehaviour
{

    public GameObject[] tier1maps;
    public GameObject[] tier2maps;
    public GameObject[] tier3maps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReMap(int wave) {
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
        MapRotableCheck mrc = map.GetComponent<MapRotableCheck>();
        if (mrc != null && mrc.IsRotable)
        {
            float initialRotation = Random.Range(0.0f, 360.0f);
            Instantiate(map, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, initialRotation, 0.0f, 1.0f));
        }
    }
}
