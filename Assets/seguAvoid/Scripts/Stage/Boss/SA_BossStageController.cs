using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class SA_BossStageController : MonoBehaviour
{
    public GameObject turtleBack;
    public GameObject Liver;
    public GameObject player;
    public GameObject Germ;
    public bool StageOn;

    public VideoClip defeat;
    public enum BOSS_STATE
    {
        BOSS_START,
        BOSS_FIGHTING,
        BOSS_DEFEAT
    }

    public BOSS_STATE state
    {
        get;
        set;
    }

    public enum BOSS_OBSTACLE
    {
        OBS_NONE,
        OBS_CREAM,
        OBS_ELDENRING,
        OBS_KNIFE,
        OBS_MOTTO
    }

    public BOSS_OBSTACLE state_obs
    {
        get;
        set;
    }

    float turtleBack_time;
    public float creamFish_time;
    public float LiverGen_time;
    public float Ring_time;
    public bool existLiver;
    public bool knives;

    float startdelayTime = 0;
    bool started = false;

    bool defeated = false;
    bool germP = false;

    int beforeIndex = -1;
    int think = -1;
    // Start is called before the first frame update
    void OnEnable()
    {
        knives = false;
        turtleBack_time = 0;
        creamFish_time = 0;
        LiverGen_time = 0;
        Ring_time = 0;
        startdelayTime = 0;
        existLiver = false;
        started = false;
        defeated = false;
        germP = false;
        state = BOSS_STATE.BOSS_START;
        player.GetComponent<SA_HealthController>().health = player.GetComponent<SA_HealthController>().Maxhealth;
        SA_UIManager.instance.healthCheck(player.GetComponent<SA_HealthController>().health);
        transform.GetChild(1).GetChild(0).GetComponent<RawImage>().color = new Color(1,1,1,0);
        transform.GetChild(1).GetChild(0).GetComponent<VideoPlayer>().Play();
        transform.GetChild(1).GetChild(0).GetComponent<VideoPlayer>().Pause();
        SecurityPlayerPrefs.SetInt("BossCleared", 1);
        transform.GetChild(0).GetChild(6).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(startdelayTime < Mathf.PI)
        {
            startdelayTime += Time.deltaTime;
            transform.GetChild(1).GetChild(0).GetComponent<RawImage>().color = new Color(1, 1, 1, ((Mathf.Cos(startdelayTime) / 2 * -1) * 2));
        }
        else if(started == false)
        {
            transform.GetChild(1).GetChild(0).GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
            transform.GetChild(1).GetChild(0).GetComponent<VideoPlayer>().Play();
            transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
            started = true;
        }
        
        if(started && transform.GetChild(1).GetChild(0).GetComponent<VideoPlayer>().isPlaying == false && state == BOSS_STATE.BOSS_START)
        {
            state = BOSS_STATE.BOSS_FIGHTING;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        }



        if (state == BOSS_STATE.BOSS_FIGHTING)
        {
            Think();
            turtleShoot(3);
            SummonLiver(5);
            creamFish(1);
            EldenRing(1);
            knife();
            motto();
        }

        if(state == BOSS_STATE.BOSS_DEFEAT && defeated == false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(1).GetComponent<AudioSource>().Play();
            Invoke("PopUpGerm",1.9f);
            defeated = true;
            
        }
        if (germP&&transform.GetChild(1).GetChild(1).GetComponent<VideoPlayer>().isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }

    void PopUpGerm()
    {
        GameObject.Instantiate(Germ, new Vector2(0,0), Quaternion.identity);
        germP = true;
    }

    void Think()
    {
        if(state_obs == BOSS_OBSTACLE.OBS_NONE)
        {
            do
            {
                think = Random.Range(0, 4);
            } while (beforeIndex == think);
            beforeIndex = think;
            switch (think)
            {
                case 0:
                    state_obs = BOSS_OBSTACLE.OBS_CREAM;
                    break;
                case 1:
                    state_obs = BOSS_OBSTACLE.OBS_ELDENRING;
                    break;
                case 2:
                    state_obs = BOSS_OBSTACLE.OBS_KNIFE;
                    break;
                case 3:
                    state_obs = BOSS_OBSTACLE.OBS_MOTTO;
                    break;
            }
        }
    }

    void turtleShoot(float term)
    {
        turtleBack_time += Time.deltaTime;
        if (turtleBack_time >= term)
        {
            var ttb = GameObject.Instantiate(turtleBack,new Vector2(Random.Range(-8f,8f),5.7f),Quaternion.identity);
            ttb.transform.parent = transform.GetChild(0);
            turtleBack_time = 0;
        }
    }

    void SummonLiver(float term)
    {

        if (LiverGen_time >= term && existLiver == false)
        {
            var liver = GameObject.Instantiate(Liver,new Vector2(Random.Range(-6.75f,6.75f),6.17f),Quaternion.identity);
            liver.transform.parent = transform.GetChild(0);
            existLiver = true;
        }
        else if(LiverGen_time < term)
        {
            LiverGen_time += Time.deltaTime;
        }
    }

    void creamFish(float term)
    {
        if (state_obs == BOSS_OBSTACLE.OBS_CREAM)
        {
            if (creamFish_time >= term && transform.GetChild(0).GetChild(0).gameObject.activeSelf == false && transform.GetChild(0).GetChild(1).gameObject.activeSelf == false)
            {
                transform.GetChild(0).GetChild(Random.Range(0, 2)).gameObject.SetActive(true);
                Invoke("InvokeFish", 8);
            }
            else
            {
                creamFish_time += Time.deltaTime;
            }
        }
    }

    void InvokeFish()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        creamFish_time = 0;
        state_obs = BOSS_OBSTACLE.OBS_NONE;
    }

    void EldenRing(float term)
    {
        if(state_obs == BOSS_OBSTACLE.OBS_ELDENRING)
        {
            if (Ring_time >= term && transform.GetChild(0).GetChild(0).gameObject.activeSelf == false)
            {
                transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                Ring_time += Time.deltaTime;
            }
        }
    }

    void InvokeRing()
    {
        transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        Ring_time = 0;
        state_obs = BOSS_OBSTACLE.OBS_NONE;
    }

    void knife()
    {
        if(state_obs == BOSS_OBSTACLE.OBS_KNIFE&&knives == false)
        {
            transform.GetChild(0).GetChild(Random.Range(3,5)).gameObject.SetActive(true);
            knives = true;
        }
    }

    void motto()
    {
        if(state_obs == BOSS_OBSTACLE.OBS_MOTTO)
        {
            transform.GetChild(0).GetChild(5).gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        ///SecurityPlayerPrefs.SetInt("BossCleared", 0);
        int a = transform.GetChild(0).childCount;
        for(int i = 0; i<a-2; i++)
        {
            transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }
        int b = transform.GetChild(0).childCount-1;
        for(int j = b; j>7; j--)
        {
            Destroy(transform.GetChild(0).GetChild(j).gameObject);
        }
        CancelInvoke("InvokeFish");
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
