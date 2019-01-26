using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour
{

    private float initialRotation;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        float initialRotation = Random.Range(0.0f, 360.0f);
        transform.eulerAngles = new Vector3(0.0f, initialRotation, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime);
    }
}
