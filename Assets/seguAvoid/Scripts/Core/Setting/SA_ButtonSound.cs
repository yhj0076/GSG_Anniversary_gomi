using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SA_ButtonSound : MonoBehaviour
{
    public AudioClip click;
    public void ClickSound()
    {
        GetComponent<AudioSource>().PlayOneShot(click);
    }
}
