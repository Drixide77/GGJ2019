using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{

    private Rigidbody body;
    private float InputX, InputY, originalSpeedFactor, originalRotationFactor;
    private List<GameObject> conches;
    public bool pause;
    public int score, playerId;
    public float backFactor, forwardSpeedFactor, rotationSpeedFactor, speed, rotationSpeed;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        body = GetComponent<Rigidbody>();
        conches = new List<GameObject>();
        pause = true;
        originalSpeedFactor = forwardSpeedFactor;
        originalRotationFactor = rotationSpeedFactor;

        if (animator != null) animator.speed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!pause) ManageAlternativeInput();
        else {
            InputX = 0.0f;
            InputY = 0.0f;
        }
        */
    }

    void FixedUpdate()
    {
        Debug.Log("Player pause: "+pause);
        if (!pause) ManageAlternativeInput();
        else
        {
            InputX = 0.0f;
            InputY = 0.0f;
        }
    }

    public void ManageInput() { 
        InputX = Input.GetAxis("Horizontal"+playerId);
        InputY = Input.GetAxis("Vertical");
        body.velocity = (transform.forward * InputY) * speed * Time.fixedDeltaTime;
        transform.Rotate((transform.up * InputX) * rotationSpeed * Time.fixedDeltaTime);
    }

    public void ManageAlternativeInput() {
        InputX = Input.GetAxis("Horizontal" + playerId);
        InputY = (Input.GetAxis("Fire1_" + playerId) * forwardSpeedFactor) - (Input.GetAxis("Fire2_" + playerId)) / backFactor;
        body.AddForce(InputY* transform.forward * speed * Time.fixedDeltaTime);
        //body.velocity += (transform.forward * InputY) * (speed) * Time.fixedDeltaTime;
        transform.Rotate((transform.up * InputX) * (rotationSpeed - rotationSpeedFactor) * Time.fixedDeltaTime);

        float mag = Mathf.Abs(body.velocity.magnitude);
        if (Mathf.Abs(InputX) > 0.2f) mag += 0.5f;
        // Debug.Log("Velocity Magnitude: "+ mag);
        animator.speed = Mathf.Min(1.0f, mag);
    }

    public void AddConch(GameObject conch) {
        conches.Add(conch);
        ++score;
        forwardSpeedFactor /= 1.5f;
        rotationSpeedFactor *= 1.25f;
    }

    public int GetConchCount() {
        return conches.Count;
    }

    public GameObject GetLastConch()
    {
        if (conches.Count > 0) return conches[conches.Count - 1];
        else return null;
    }

    public void CallCleanShells() {
        for (int i = conches.Count - 1; i >= 0; --i) {
            Destroy(conches[i]);
        }
        score = score - (score%3);
        conches.Clear();
        forwardSpeedFactor = originalSpeedFactor;
        rotationSpeedFactor = originalRotationFactor;
    }

    IEnumerator CleanShells() {
        yield return new WaitForSeconds(1.0f);
        CallCleanShells();
    }


    public void CallTheShellCoroutine() {
        // StartCoroutine(CleanShells());
        CallCleanShells();
    }
}
