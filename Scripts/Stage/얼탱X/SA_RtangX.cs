using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_RtangX : MonoBehaviour
{
    public GameObject OB;
    AudioSource soundPlayer;

    public bool StageOn;

    public GameObject platform;
    public GameObject siling;
    public bool PlatformDown;
    // Update is called once per frame
    void Update()
    {
        if (soundPlayer.isPlaying == false)
        {
            StageOn = false;
            PlatformDown = false;
            
            Invoke("delayFalse", 2f);
        }
        if (StageOn)
        {
            transform.GetChild(0).position = Vector2.Lerp(transform.GetChild(0).position, Vector2.zero, 0.08f);     
            transform.GetChild(1).position = Vector2.Lerp(transform.GetChild(1).position, new Vector2(0,3f), 0.08f);         //     1
            transform.GetChild(2).position = Vector2.Lerp(transform.GetChild(2).position, new Vector2(-4.55f,-0.3f), 0.08f);        //  2     3
            transform.GetChild(3).position = Vector2.Lerp(transform.GetChild(3).position, new Vector2(4.55f,-0.3f), 0.08f);         //     4
            transform.GetChild(4).position = Vector2.Lerp(transform.GetChild(4).position, new Vector2(0,-4.5f), 0.08f);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).position = Vector2.Lerp(transform.GetChild(1).position, new Vector2(0, 6), 0.08f);         //     1
            transform.GetChild(2).position = Vector2.Lerp(transform.GetChild(2).position, new Vector2(-11, 0), 0.08f);        //  2     3
            transform.GetChild(3).position = Vector2.Lerp(transform.GetChild(3).position, new Vector2(11, 0), 0.08f);         //     4
            transform.GetChild(4).position = Vector2.Lerp(transform.GetChild(4).position, new Vector2(0, -6), 0.08f);
        }

        if (PlatformDown)
        {
            platform.transform.localPosition = Vector2.Lerp(platform.transform.localPosition, new Vector2(0,-10f), 0.08f);
        }
        else
        {
            platform.transform.localPosition = Vector2.Lerp(platform.transform.localPosition, new Vector2(0,-4.75f), 0.08f);
        }

        
    }

    private void OnEnable()
    {
        StageOn = true;
        OB.GetComponent<SA_OutOfBound>().DamageOn = true;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).position = new Vector2(0,10);
        siling.SetActive(false);
        Invoke("InvokeSpin", 3.6f);
        Invoke("delayDeletePlatform",1.3f);
    }

    void delayDeletePlatform()
    {
        PlatformDown = true;
        
    }

    void InvokeSpin()
    {
        transform.GetChild(0).GetComponent<SA_SpinX>().spin = true;
    }

    void delayFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        siling.SetActive(true);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
