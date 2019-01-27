using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicController : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayDefaultMusic() {
        audioSource.Stop();
        audioSource.clip = clip[0];
        audioSource.Play();
    }

    public void PlayFasterMusic() {
        audioSource.Stop();
        audioSource.clip = clip[1];
        audioSource.Play();
    }
}
