using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_SFX_Check : MonoBehaviour
{
    AudioSource soundPlayer;

    private void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    public void StartSound()
    {
        soundPlayer.Play();
    }
}
