using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class SA_MuSeven : MonoBehaviour
{
    AudioSource soundPlayer;

    bool StageOn = false;
    float time = 0;

    public GameObject Fox;
    public GameObject JRR;
    public GameObject Mu7ryun;
    public GameObject Player;
    public GameObject OB;
    bool fox = false;
    bool jrr = false;
    bool m7r = false;
    public bool Paused;
    private void OnEnable()
    {
        Paused = false;
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        time = 0;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.PlayDelayed(1f);
        StageOn = true;
        fox = false;
        jrr = false;
        m7r = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>=1.3f&&time<2.6f&&fox == false)
        {
            var foxRyun = GameObject.Instantiate(Fox, transform.GetChild(1).position,Quaternion.identity).transform.parent = transform.GetChild(1);
            fox = true;
        }
        else if(time>=2.6f&&time<5.9f&&jrr == false)
        {
            var Muchin = GameObject.Instantiate(JRR, transform.GetChild(2).position, Quaternion.identity).transform.parent = transform.GetChild(2);
            jrr = true;
        }
        else if(time >=5.9f && time < 6.7f)
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
        else if(time >= 6.7f  && time < 7.7f)
        {
            transform.GetChild(3).GetComponent<SA_DangerMu7>().stop = true;
        }
        else if(time>=7.7f&&m7r == false)
        {
            transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Instantiate(Mu7ryun, new Vector2(10.5f, transform.GetChild(3).position.y), Quaternion.identity);
            m7r = true;
        }




        if(StageOn)
        {
            transform.GetChild(0).GetChild(0).localPosition = Vector2.Lerp(transform.GetChild(0).GetChild(0).localPosition,new Vector2(0,0),0.08f);
        }
        else
        {
            transform.GetChild(0).GetChild(0).localPosition = Vector2.Lerp(transform.GetChild(0).GetChild(0).localPosition, new Vector2(0, -1080), 0.08f);
        }

        

        if(Paused == true && transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().isPlaying)
        {
            transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Pause();
        }
        else if (Paused == false && transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().isPlaying==false)
        {
            transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Play();
        }
        if (soundPlayer.isPlaying == false && Paused == false)
        {
            StageOn = false;
            Invoke("delayFalse", 0.1f);
        }
    }

    void delayFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Destroy(transform.GetChild(1).GetChild(0).gameObject);
        Destroy(transform.GetChild(2).GetChild(0).gameObject);
        transform.GetChild(0).localPosition = new Vector2(-12.15f, 0);
        transform.GetChild(1).localPosition = new Vector2(5.73f, 0.44f);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
