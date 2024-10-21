using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_PlaySFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] audioClips;
    public static SG_PlaySFX sgplaySFX;

    private void Awake()
    {
        sgplaySFX = this;
    }
    public void playSFX(int index) // 0 : Hit , 1 : Success, 2 : Fail, 3 : Parkour Start, 4 : Parkour End, 5 : SavePoint, 6 : Glitch, 7 : 넘기 SFX, 8 : Dash SFX, 9 : Slider, 10 : Roll, 11 : Right Foot SFX, 12 : Left Foot SFX 
    {
        SG_UIController.UIcont.AudioSources[1].PlayOneShot(audioClips[index]);
    }
}
