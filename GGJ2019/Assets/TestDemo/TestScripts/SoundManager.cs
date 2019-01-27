using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public GameMusicController GameMusic;
    public StarSoundManager StarSounds;
    public WaveSoundController WaveSounds;
    public StartRoundControlller StartRoundSounds;
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

    public void PlayWaveSound() {
        WaveSounds.PlayWaveFX();
    }

    public void PlayStartRoundSound() {
        StartRoundSounds.PlayStartSound();
    }
}
