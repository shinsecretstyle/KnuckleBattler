using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public AudioClip testClip; // デバッグ用のクリップ

    void Start()
    {
        if (testClip == null)
        {
            Debug.LogError("Test Clip is not assigned!");
        }
    }
}

