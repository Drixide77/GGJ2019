using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public GameMusicController GameMusic;
    public StarSoundManager StarSounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayIngameMusic() {
        GameMusic.PlayDefaultMusic();
    }

    public void PlaySpeedUpMusic() {
        GameMusic.PlayFasterMusic();
    }

    public void PlayStarSound() {
        StarSounds.PlayStarAcquired();
    }

    public void PlayWinSound() {
        StarSounds.PlayWinSound();
    }

}
