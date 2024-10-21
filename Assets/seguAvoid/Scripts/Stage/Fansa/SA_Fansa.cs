using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
public class SA_Fansa : MonoBehaviour
{
    AudioSource soundPlayer;
    float time = 0;

    // 0 : 응원봉경고
    // 1 : 응원봉
    // 2 : 빔 경고
    // 3 : 빔



    bool danger1;
    bool foo1;
    bool danger2;
    bool foo2;
    bool danger3;
    bool beamlock;
    bool beam;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.6f && danger1 == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            danger1 = true;
        }
        else if (time >= 3.5f && foo1 == false)             //못또
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            foo1 = true;
        }
        else if (time >= 4.4f && danger2 == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            danger2 = true;
        }
        else if (time >= 6.2f && foo2 == false)             //못또
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            foo2 = true;
        }
        else if (time >= 7.3f && danger3 == false)          //보답
        {
            transform.GetChild(2).gameObject.SetActive(true);
            danger3 = true;
        }
        else if (time >= 9.7f && beamlock == false)          //사랑을 가득
        {
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
            beamlock = true;
        }
        else if (time >= 11f && beam == false)            //세구빔으로
        {
            transform.GetChild(3).GetComponent<SA_BEEEEEEEEAM>().Beam = true;
            beam = true;
        }
        if (soundPlayer.isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        danger1 = false;
        foo1 = false;
        danger2 = false;
        foo2 = false;
        danger3 = false;
        beamlock = false;
        beam = false;
        time = 0;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(4).GetChild(0).GetComponent<VideoPlayer>().Play();
    }

    private void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
