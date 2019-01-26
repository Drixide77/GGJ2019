using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject root;
    public Material highlightmat, unhighlightmat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void Highlight()
    {
        if (highlightmat != null)
        {
            gameObject.GetComponent<Renderer>().material = highlightmat;
        }
    }

    public void Unhighlight() {
        if (unhighlightmat != null)
        {
            gameObject.GetComponent<Renderer>().material = unhighlightmat;
        }
    }

    public GameObject GetRoot() {
        return root;
    }
}
