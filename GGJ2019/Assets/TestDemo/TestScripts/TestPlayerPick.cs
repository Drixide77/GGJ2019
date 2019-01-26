using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerPick : MonoBehaviour
{
    public RigidBodyMovement rbm;
    private Rigidbody body;
    public GameObject conch, cup, can, initialAnchor, tailOut, tailIn;
    public Transform newCapsulePos;


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
            GameObject target = other.gameObject;
            PickUpScript pus = target.GetComponent<PickUpScript>();
            if (pus != null) {
                if (tailOut != null) {
                    Destroy(tailOut);
                    tailIn.SetActive(true);
                    gameObject.transform.position = newCapsulePos.position;
                }
                GameObject toSpawn = null;
                switch (pus.GetRoot().tag) {
                    case "Conch": {
                            toSpawn = conch;
                            break;
                    }
                    case "Cup":
                        {
                            toSpawn = cup;
                            break;
                        }
                    case "Can":
                        {
                            toSpawn = can;
                            break;
                        }
                }
                Destroy(pus.GetRoot());
                GameObject lastShell = rbm.GetLastConch();
                Transform conchAnchor;
                if (lastShell == null) conchAnchor = initialAnchor.transform;
                else {
                    conchAnchor = lastShell.GetComponent<ConchScript>().GetAnchor().transform;
                }
                GameObject addedConch = Instantiate(toSpawn, conchAnchor.position, conchAnchor.rotation);
                addedConch.transform.parent = conchAnchor;
                rbm.AddConch(addedConch);
            }
        }
    }

    

    public void DoPickUp()
    {

    }
}
