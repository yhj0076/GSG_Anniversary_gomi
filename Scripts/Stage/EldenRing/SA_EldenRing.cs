using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_EldenRing : MonoBehaviour
{
    AudioSource soundPlayer;
    public bool Paused;

    float time = 0;

    bool Danger1;
    bool Danger2;
    bool Danger3;
    bool Danger4;
    bool Axe1;
    bool Axe2;
    bool Axe3;
    bool Axe4;
    private void OnEnable()
    {
        Paused = false;
        time = 0;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        Danger1 = false;
        Danger2= false;
        Danger3 = false;
        Danger4 = false;
        Axe1 = false;
        Axe2 = false;
        Axe3 = false;
        Axe4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 0.75f && Danger1 == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Danger1 = true;
        }
        else if(time > 1.5f && Axe1 == false)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            Axe1 = true;
        }
        else if (time > 2.25f && Danger2 == false)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            Danger2 = true;
        }
        else if (time > 3f && Axe2 == false)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            Axe2 = true;
        }
        else if (time > 3.75f && Danger3 == false)
        {
            transform.GetChild(4).gameObject.SetActive(true);
            Danger3 = true;
        }
        else if (time > 4.5f && Axe3 == false)
        {
            transform.GetChild(5).gameObject.SetActive(true);
            Axe3 = true;
        }
        else if (time > 5.25f && Danger4 == false)
        {
            transform.GetChild(6).gameObject.SetActive(true);
            Danger4 = true;
        }
        else if (time > 6f && Axe4 == false)
        {
            transform.GetChild(7).gameObject.SetActive(true);
            Axe4 = true;
        }


        if (soundPlayer.isPlaying == false && Paused == false && Axe4 && transform.GetChild(7).gameObject.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
