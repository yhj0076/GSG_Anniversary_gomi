using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DoctorGo : MonoBehaviour
{
    public GameObject Heal;
    public AudioClip yes;
    public AudioClip no;

    AudioSource soundPlayer;

    float time = 0;
    bool GiveHeal = false;

    public bool Paused;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>2.5f&&GiveHeal==false)
        {
            int RandX = Random.Range(-5,6);
            var healing = Instantiate(Heal,new Vector2(RandX,0),Quaternion.identity);
            GiveHeal = true;
        }

        if(soundPlayer.isPlaying == false && Paused == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Paused = false;
        soundPlayer = GetComponent<AudioSource>();

        GiveHeal = false;
        soundPlayer.clip = no;

        time = 0;
        soundPlayer.Play();
    }

    private void OnDisable()
    {
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
