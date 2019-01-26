using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInstantiator : MonoBehaviour
{
    
    public GameObject[] pickups;

    // Start is called before the first frame update
    void Start()
    {
        int type = DecideType();
        float randX = Random.Range(0.0f, 360.0f);
        float randY = Random.Range(0.0f, 360.0f);
        float randZ = Random.Range(0.0f, 360.0f);
        GameObject pickUp = Instantiate(pickups[type], transform.position, new Quaternion(randX, randY, randZ, 1.0f));
        pickUp.transform.parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int DecideType() {
        int probability = Random.Range(0,100);
        if (probability <= 100 && probability > 75) return 2;
        if (probability <= 75 && probability > 50) return 1;
        return 0;
    }
}