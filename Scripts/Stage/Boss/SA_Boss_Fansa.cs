using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_Boss_Fansa : MonoBehaviour
{
    AudioSource soundPlayer;
    float time = 0;

    bool danger1;
    bool foo1;
    bool danger2;
    bool foo2;
    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.6f && danger1 == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            danger1 = true;
        }
        else if (time >= 3.5f && foo1 == false)
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
        else if (time >= 6.2f && foo2 == false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            foo2 = true;
        }

        if(soundPlayer.isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        danger1 = false;
        foo1    = false;
        danger2 = false;
        foo2    = false;
        time = 0;
    }

    private void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.parent.parent.GetComponent<SA_BossStageController>().state_obs = SA_BossStageController.BOSS_OBSTACLE.OBS_NONE;
    }
}
