using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{

    private Rigidbody body;
    public float speed;
    public float rotationSpeed;
    private float InputX, InputY;
    private List<GameObject> conches;
    public bool pause;
    public int score;
    public int playerId;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        body = GetComponent<Rigidbody>();
        conches = new List<GameObject>();
        pause = false;
        //pause = true; Uncomment Later
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause) ManageInput();       
    }

    public void ManageInput() { 
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        body.velocity = (transform.forward * InputY) * speed * Time.fixedDeltaTime;
        transform.Rotate((transform.up * InputX) * rotationSpeed * Time.fixedDeltaTime);
    }

    public void AddConch(GameObject conch) {
        conches.Add(conch);
        ++score;
    }

    public GameObject GetLastConch()
    {
        if (conches.Count > 0) return conches[conches.Count - 1];
        else return null;
    }
}
