using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SA_OneChipController : MonoBehaviour
{
    public GameObject OB;
    AudioSource soundPlayer;

    public bool StageOn;
    public bool Paused;
    // Update is called once per frame
    void Update()
    {
        /*if(StageOn)
        {
            transform.GetChild(1).localPosition = Vector2.Lerp(transform.GetChild(1).localPosition,new Vector2(-6.41f, -2.068301f),0.08f);   // 고세구 몸뚱애리
            transform.GetChild(2).localPosition = Vector2.Lerp(transform.GetChild(2).localPosition,new Vector2(0.4384303f, 0.35f),0.08f);   // 쥬시쿨
        }
        else
        {
            transform.GetChild(1).localPosition = Vector2.Lerp(transform.GetChild(1).localPosition, new Vector2(-10.99f, -2.068301f), 0.08f); // 고세구 몸뚱애리
            transform.GetChild(2).localPosition = Vector2.Lerp(transform.GetChild(2).localPosition, new Vector2(0.4384303f, -3.51f), 0.08f);   // 쥬시쿨
        }*/
        if (StageOn)
        {
            transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().localPosition = 
                Vector2.Lerp(transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().localPosition, new Vector2(-695.5f, -257), 0.08f); // 영상
            transform.GetChild(1).localPosition = Vector2.Lerp(transform.GetChild(1).localPosition, new Vector2(0, 0), 0.08f);  // 발판
        }
        else
        {
            transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().localPosition =
                Vector2.Lerp(transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().localPosition, new Vector2(-1225, -257), 0.08f);   // 영상
            transform.GetChild(1).localPosition = Vector2.Lerp(transform.GetChild(1).localPosition, new Vector2(10.28f, 0), 0.08f); // 발판
        }

        if (soundPlayer.isPlaying == false && Paused == false)
        {
            StageOn = false;
            delayFalse();
            Invoke("delayFalse",1f);
        }

    }

    private void OnEnable()
    {
        Paused = false;
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        StageOn = true;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        transform.GetChild(1).gameObject.SetActive(true);   //PAQUI
        transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Play();
        Invoke("delayJuicy",5.3f);
        Invoke("delayFire1",6.8f);
        Invoke("falseJuicy",7.9f);

        Invoke("delayJuicy", 8.0f);
        Invoke("delayFire2", 9.0f);
        Invoke("falseJuicy", 10.1f);

        Invoke("delayJuicy",10.2f);
        Invoke("delayFire3",11.2f);
    }

    void delayFire1()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        
    }
    void delayFire2()
    {
        transform.GetChild(3).gameObject.SetActive(true);
    }
    void delayFire3()
    {
        transform.GetChild(4).gameObject.SetActive(true);
    }

    void delayJuicy()
    {
        transform.GetChild(5).gameObject.SetActive(true);
    }

    void falseJuicy()
    {
        transform.GetChild(5).gameObject.SetActive(false);
    }

    void delayFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        int a = transform.childCount;
        for(int i = 1; i<a; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        CancelInvoke("delayJuicy");
        CancelInvoke("delayFire1");
        CancelInvoke("delayFire2");
        CancelInvoke("falseJuicy");
        CancelInvoke("delayFire3");
        transform.GetChild(1).localPosition = new Vector2(10.28f, 0); // 발판
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
