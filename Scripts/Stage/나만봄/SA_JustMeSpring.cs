using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
/* 1.3 신기전 등장
 * 3.8 발사
 * 4.6 다른 사람 다 사라져라
 * 
 * 9.5초 후두둑
 */

public class SA_JustMeSpring : MonoBehaviour
{
    AudioSource soundPlayer;
    public bool StageOn;
    public GameObject Arrows;
    bool move;
    bool blast;

    public float time = 0;
    public bool Paused;

    bool play;
    bool Played;
    // Start is called before the first frame update
    void OnEnable()
    {
        Paused = false;
        StageOn = true;
        Played = false;
        play = false;
        blast = false;
        move = true;
        time = 0;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
    }

    void InvokePause()
    {
        if (transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().isPlaying && play == false)
        {
            transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Pause();
            play = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 4.4f)
        {
            InvokePause();
        }
        if (time >= 1.3f && time < 3.0f) // 1.3~3.8
        {
            transform.GetChild(0).GetChild(0).localPosition = Vector2.Lerp(transform.GetChild(0).GetChild(0).localPosition, new Vector2(0,0), 0.08f);
            transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Play();
            transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Pause();
        }
        else if(time>=3.0f && time<4.6f && Played == false) // 3.8~4.6
        {
            transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Play();
            Played = true;
        }
        else if(time >= 4.6f && time < 9.5f)
        {
            if (transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().isPlaying && play == false)
            {
                transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Pause();
                play = true;
            }
            if (move)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                move = false;
            }
        }
        else if (time>=9.5f && time < 11.3f)
        {
            if (blast==false)
            {
                transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                transform.GetChild(1).GetComponent<SA_MovingArea>().moving = false;
                var Arrow1 = GameObject.Instantiate(Arrows,Vector2.zero,Quaternion.identity);
                Arrow1.transform.parent = transform.GetChild(1);
                Arrow1.transform.localPosition = new Vector2(-8.7f,0);
                Arrow1.transform.localScale = Arrows.transform.localScale;

                var Arrow2 = GameObject.Instantiate(Arrows, Vector2.zero, Quaternion.identity);
                Arrow2.transform.parent = transform.GetChild(1);
                Arrow2.transform.localPosition = new Vector2(9.8f,0);
                Arrow2.transform.localScale = Arrows.transform.localScale;

                blast = true;
            }
        }
        else if (time >= 11.3f && time < 12.8f)
        {
            transform.GetChild(0).localPosition = Vector2.Lerp(transform.GetChild(0).localPosition,new Vector2(10.61f,-3.18f),0.08f);
        }

        if(soundPlayer.isPlaying == false && Paused == false)
        {
            gameObject.SetActive(false);
        }

        if(Paused == true && Played == true)
        {
            transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Pause();
        }
        else if(Paused == false && Played == true && play == false)
        {
            transform.GetChild(0).GetChild(0).GetComponent<VideoPlayer>().Play();
        }
    }

    private void OnDisable()
    {
        transform.GetChild(1).GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        transform.GetChild(0).localPosition = new Vector2(10.61f,-3.18f);
        Destroy(transform.GetChild(1).GetChild(2).gameObject);
        Destroy(transform.GetChild(1).GetChild(3).gameObject);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
