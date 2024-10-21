using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_YeaYea : MonoBehaviour
{
    float time = 0;

    AudioSource soundPlayer;
    public GameObject OB;
    public float[] onTime = new float[9];

    public bool Paused;

    // Update is called once per frame
    void Update()
    {

            time += Time.deltaTime;

        if (time >= onTime[0] && time < onTime[1])
        {
            transform.GetChild(2).gameObject.SetActive(true);   // DangerZone_smallSky
        }
        else if(time >= onTime[1] && time < onTime[2])
        {
            transform.GetChild(0).gameObject.SetActive(true);   // sky_small 1
        }
        else if (time >= onTime[2] && time < onTime[3])
        {
            transform.GetChild(1).gameObject.SetActive(true);   // sky_small 2
        }
        else if (time >= onTime[3] && time < onTime[4])
        {
            transform.GetChild(5).gameObject.SetActive(true);   // DangerZone_smallFloor
        }
        else if (time >= onTime[4] && time < onTime[5])
        {
            transform.GetChild(3).gameObject.SetActive(true);   // floor_left
        }
        else if (time >= onTime[5] && time < onTime[6])
        {
            transform.GetChild(4).gameObject.SetActive(true);   // floor_right
        }
        else if (time >= onTime[6] && time < onTime[7])
        {
            transform.GetChild(8).gameObject.SetActive(true);   // DangerZone_sky_Big
        }
        else if (time >= onTime[7] && time < onTime[8])
        {
            transform.GetChild(9).gameObject.SetActive(true);   // DangerZone_sky_Big2
        }
        else if (time >= onTime[8] && time < onTime[9])
        {
            transform.GetChild(6).gameObject.SetActive(true);   // sky_Big left
        }
        else if (time >= onTime[9])
        {
            transform.GetChild(7).gameObject.SetActive(true);   // sky_Big right
        }

        if (soundPlayer.isPlaying == false && Paused == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Paused = false;
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        time = 0;
    }

    private void OnDisable()
    {
        transform.GetChild(7).gameObject.SetActive(false);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
