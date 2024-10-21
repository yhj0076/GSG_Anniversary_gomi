using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_FishBreadRain : MonoBehaviour
{
    public GameObject fishBread;
    public GameObject OB;
    AudioSource soundPlayer;

    public bool Paused;
    private void OnEnable()
    {
        Paused = false;
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        soundPlayer = GetComponent<AudioSource>(); 
        soundPlayer.Play();
        Invoke("delayOn",4.1f);
        Invoke("delayOn2", 8.2f);
    }

    void delayOn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    void delayOn2()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(soundPlayer.isPlaying == false && Paused == false)
        {
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(false); 
            }
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        CancelInvoke("delayOn");
        CancelInvoke("delayOn2");
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
