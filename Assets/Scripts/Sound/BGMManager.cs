using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip bgmClip; // インスペクタで割り当てるBGMファイル
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGM();
    }

    void PlayBGM()
    {
        if (bgmClip != null && audioSource != null)
        {
            audioSource.clip = bgmClip;
            audioSource.loop = true; // ループ再生
            audioSource.Play();
        }
    }
}