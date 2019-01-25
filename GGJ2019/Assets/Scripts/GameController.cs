using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Fader fader;

    // Start is called before the first frame update
    void Start() {
        Unfade();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Unfade()
    {
        if (!fader.gameObject.activeInHierarchy) fader.gameObject.SetActive(true);
        fader.DoFade(0.0f, 0.2f, (finish) => { });
    }
}
