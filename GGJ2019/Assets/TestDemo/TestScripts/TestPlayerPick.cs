using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerPick : MonoBehaviour
{
    private RigidBodyMovement rbm;
    private Rigidbody body;
    public GameObject conch, initialAnchor, tailOut, tailIn;
    public Transform newCapsulePos;
    public int playerId;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        rbm = transform.parent.gameObject.GetComponent<RigidBodyMovement>();
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
                if (tailOut != null) {
                    Destroy(tailOut);
                    tailIn.SetActive(true);
                    gameObject.transform.position = newCapsulePos.position;
                }
                Destroy(target);
                GameObject lastConch = rbm.GetLastConch();
                Transform conchAnchor;
                if (lastConch == null) conchAnchor = initialAnchor.transform;
                else {
                    conchAnchor = lastConch.GetComponent<ConchScript>().GetAnchor().transform;
                }
                GameObject addedConch = Instantiate(conch, conchAnchor.position, conchAnchor.rotation);
                addedConch.transform.parent = conchAnchor;
                rbm.AddConch(addedConch);
            }
        }
    }

    

    public void DoPickUp()
    {

    }
}
