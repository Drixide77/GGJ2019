using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFXController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButtonFX()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    public void PlayJoinFX()
    {
        audioSource.clip = clips[1];
        audioSource.Play();
    }
}

