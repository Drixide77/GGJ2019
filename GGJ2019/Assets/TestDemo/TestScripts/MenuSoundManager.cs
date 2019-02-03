using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{

    public MenuFXController fx;
    public MenuMusicController music;
    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMenuMusic() {
        music.PlayMusic();
    }

    public void PlayButtonFX() {
        fx.PlayButtonFX();
    }

    public void PlayButtonHigh() {
        if (!first) fx.PlayButtonHighlight();
        else first = false;
    }

}
