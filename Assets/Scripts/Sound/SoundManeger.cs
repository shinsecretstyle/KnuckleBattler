using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundEffect; // インスペクタで割り当てる効果音
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(soundEffect);
    }
}