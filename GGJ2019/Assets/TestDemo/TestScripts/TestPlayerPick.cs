using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerPick : MonoBehaviour
{

    private Rigidbody body;
    public GameObject conch;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUpPoint")
        {
            Debug.Log("Entered");
            GameObject target = other.gameObject;
            PickUpScript pus = target.GetComponent<PickUpScript>();
            if (pus != null) {
                Destroy(target);
                GameObject CreatedConch = Instantiate(conch, transform);
                CreatedConch.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            }
        }
    }

    /*private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "PickUpPoint")
        {
            PickUpScript pus = other.gameObject.GetComponent<PickUpScript>();
            if (pus != null)
            {
                Debug.Log("GotScript");
                pus.Unhighlight();
            }
        }
    }*/

    public void DoPickUp()
    {

    }
}
