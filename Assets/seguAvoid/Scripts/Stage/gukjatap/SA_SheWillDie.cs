using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_SheWillDie : MonoBehaviour
{
    AudioSource soundPlayer;
    public AudioClip Danger;

    private void OnEnable()
    {
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.PlayDelayed(1.8f);
    }
}
