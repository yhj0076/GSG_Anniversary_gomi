using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_jansangController : MonoBehaviour
{
    AudioSource soundPlayer;
    public GameObject OB;
    float time = -2;

    bool jansang1 = false;
    bool jansang2 = false;
    bool jansang3 = false;
    bool jansang4 = false;
    bool jansang5 = false;
    public bool Paused;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0f && time < 3.3f && jansang1 == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke("DangerZoneOn1", 2f);
            jansang1 = true;
        }
        else if (time>=3.3f&&time<6.2f&&jansang2==false)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            Invoke("DangerZoneOn2", 1.5f);
            jansang2 = true;
        }
        else if (time >= 6.2f && time < 9.3f && jansang3 == false)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            Invoke("DangerZoneOn3", 1.6f);
            jansang3 = true;
        }
        else if (time >= 9.3f && time < 10.8f && jansang4 == false) // 12.3
        {
            transform.GetChild(3).gameObject.SetActive(true);
            jansang4 = true;
        }
        else if (time >= 10.8f && jansang5 == false)
        {
            transform.GetChild(4).gameObject.SetActive(true);
            jansang5 = true;
        }

        if(soundPlayer.isPlaying==false && Paused == false)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        Paused = false;
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.PlayDelayed(1.6f);
        time = -1.6f;
        Invoke("DangerZoneFirst",0.5f);
        jansang1 = false;
        jansang2 = false;
        jansang3 = false;
        jansang4 = false;
        jansang5 = false;
    }

    void DangerZoneFirst()
    {
        transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
    }

    void DangerZoneOn3()
    {
        transform.GetChild(5).GetChild(3).gameObject.SetActive(true);
    }
    void DangerZoneOn2()
    {
        transform.GetChild(5).GetChild(2).gameObject.SetActive(true);
    }
    void DangerZoneOn1()
    {
        transform.GetChild(5).GetChild(1).gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        CancelInvoke("DangerZoneOn1");
        CancelInvoke("DangerZoneOn2");
        CancelInvoke("DangerZoneOn3");
        CancelInvoke("DangerZoneFirst");
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(5).GetChild(2).gameObject.SetActive(false);
        transform.GetChild(5).GetChild(3).gameObject.SetActive(false);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
