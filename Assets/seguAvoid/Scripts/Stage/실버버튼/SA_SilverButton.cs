using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_SilverButton : MonoBehaviour
{
    AudioSource soundPlayer;
    public bool StageOn;
    // Start is called before the first frame update
    void OnEnable()
    {
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        StageOn = true;
        transform.GetChild(0).localPosition = new Vector2(-0.73f,6);
        for (int i = 0; i < 12; i++)
        {
            StartCoroutine(delayRelease(i, 0.5f*(i+1)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StageOn)
        {
            transform.GetChild(0).localPosition = Vector2.Lerp(transform.GetChild(0).localPosition,new Vector2(-0.73f,2.22f),0.08f);
        }
        else
        {
            transform.GetChild(0).localPosition = Vector2.Lerp(transform.GetChild(0).localPosition, new Vector2(-0.73f, -7.61f), 0.08f);
            for(int i = 0; i<12; i++)
            {
                transform.GetChild(0).GetChild(i).GetComponent<PolygonCollider2D>().enabled = false;
            }
        }

        if (soundPlayer.isPlaying == false)
        {
            StageOn = false;
            for (int i = 0; i < 12; i++)
            {
                StartCoroutine(noRelease(i, 0.6f * i));
            }
            Invoke("delayFalse", 0.5f);
        }
    }

    void delayFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }

    IEnumerator delayRelease(int index,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.GetChild(0).GetChild(index).GetComponent<SA_FollowSilver>().go = true;
    }

    IEnumerator noRelease(int index, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.GetChild(0).GetChild(index).GetComponent<SA_FollowSilver>().go = false;
    }

}
