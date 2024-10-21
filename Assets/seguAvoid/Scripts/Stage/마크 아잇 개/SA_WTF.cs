using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_WTF : MonoBehaviour
{
    SA_SeguArm seguArm;
    AudioSource soundPlayer;
    public AudioClip WhatThe;
    public GameObject OB;
    public GameObject Leftside;
    public GameObject Rightside;
    public GameObject Platform;

    bool StageOn = false;
    float time = 0;
    public float delayTime;

    // Update is called once per frame
    void Update()
    {

            time += Time.deltaTime;

        if (time >= delayTime)
        {
            if (seguArm.NowSpinTimes >= seguArm.orbit)
            {
                transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
            }

            if (StageOn)
            {
                Leftside.transform.localPosition = Vector2.Lerp(Leftside.transform.localPosition, new Vector2(1.58f, 0f), 0.1f);
                Rightside.transform.localPosition = Vector2.Lerp(Rightside.transform.localPosition, new Vector2(0.78f, -4.136453f), 0.1f);
                Platform.GetComponent<BoxCollider2D>().size = Vector2.Lerp(Platform.GetComponent<BoxCollider2D>().size, new Vector2(2f, 1f), 0.1f);
                Platform.transform.position = Vector2.Lerp(Platform.transform.position, new Vector2(-1.17f, -4.75f), 0.1f);
                Platform.transform.GetComponent<SpriteRenderer>().size = Vector2.Lerp(Platform.transform.GetComponent<SpriteRenderer>().size, new Vector2(2, 0.5f), 0.1f);
            }
            else
            {
                transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                Leftside.transform.localPosition = Vector2.Lerp(Leftside.transform.localPosition, new Vector2(-0.95f, 0f), 0.1f);
                Rightside.transform.localPosition = Vector2.Lerp(Rightside.transform.localPosition, new Vector2(5.94f, -4.136453f), 0.1f); //6.7, -3.1
                Platform.GetComponent<BoxCollider2D>().size = Vector2.Lerp(Platform.GetComponent<BoxCollider2D>().size, new Vector2(17.77f, 1), 0.1f);
                Platform.transform.position = Vector2.Lerp(Platform.transform.position, new Vector2(0, -4.75f), 0.1f);
                Platform.transform.GetComponent<SpriteRenderer>().size = Vector2.Lerp(Platform.transform.GetComponent<SpriteRenderer>().size, new Vector2(17.77f, 0.5f), 0.1f);
                Invoke("ObjFalse", 0.5f);
            }

            if (soundPlayer.isPlaying == false)
            {
                StageOn = false;
            }
        }
    }

    void ObjFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = true;
        time = 0;
        transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).localPosition = new Vector2(1.1f,-10);
        soundPlayer = GetComponent<AudioSource>();
        // Invoke("DelaySound",delayTime);
        soundPlayer.PlayDelayed(delayTime);
        StageOn = true;
        seguArm = transform.GetChild(1).GetChild(0).GetComponent<SA_SeguArm>();
    }

    void DelaySound()
    {
        soundPlayer.Play();
    }

    private void OnDisable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        time = 0;
        Leftside.transform.localPosition = new Vector2(-0.95f, 0f);
        Rightside.transform.localPosition = new Vector2(5.94f, -4.136453f);
        Platform.GetComponent<BoxCollider2D>().size = new Vector2(17.77f, 1f);
        Platform.transform.position = new Vector2(0, -4.75f);
        Platform.transform.GetComponent<SpriteRenderer>().size = new Vector2(17.77f,0.5f);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
