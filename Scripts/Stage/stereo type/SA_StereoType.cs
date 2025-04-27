using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_StereoType : MonoBehaviour
{
    AudioSource soundPlayer;

    public Transform from;
    public Transform to;

    public GameObject cam;
    float time = 0;
    public bool Paused;
    private void OnEnable()
    {
        Paused = false;
        time = 0;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        // Invoke("delaySpin",4f);
    }

    void delaySpin()
    {
        cam.transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 4)
        {
            cam.transform.rotation = Quaternion.Lerp(from.rotation,to.rotation,(time-4));
        }

        if(soundPlayer.isPlaying == false && Paused == false)
        {
            SA_StageManager.instance.isSpinned = 1;
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }

}
