using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_EEEEEE : MonoBehaviour
{
    AudioSource soundPlayer;
    public GameObject OB;
    public GameObject gosegu;
    public GameObject Vichan;
    public GameObject E;
    public float spawnRate;
    public float delayTime;
    float timeAfterSpawn = 0;
    Transform target;

    bool StageOn = false;

    private void OnEnable()
    { 
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        OB.SetActive(false);
        target = FindObjectOfType<SA_PlayerController>().transform;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        StageOn = true;
        timeAfterSpawn = 0;
    }

    private void Update()
    {
        if (StageOn)
        {
            gosegu.transform.localPosition = Vector2.Lerp(gosegu.transform.localPosition, new Vector2(-7.02f, -2.9f), 0.1f);
            Vichan.transform.localPosition = Vector2.Lerp(Vichan.transform.localPosition, new Vector2(7.5f, -2.9f), 0.1f);
        }
        else
        {
            gosegu.transform.localPosition = Vector2.Lerp(gosegu.transform.localPosition, new Vector2(-10.5f, -2.9f), 0.1f);
            Vichan.transform.localPosition = Vector2.Lerp(Vichan.transform.localPosition, new Vector2(11f, -2.9f), 0.1f);
            Invoke("ObjFalse",0.5f);
        }
        StartCoroutine("EE");
        if(soundPlayer.isPlaying == false)
        {
            StopCoroutine("EE");
            StageOn = false;           
        }
    }

    void ObjFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        OB.SetActive(true);
        gosegu.transform.localPosition = new Vector2(-10.5f,-2.9f);
        Vichan.transform.localPosition = new Vector2(11,-2.9f);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }

    IEnumerator EE()
    {
        yield return new WaitForSeconds(delayTime);
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            Debug.Log(timeAfterSpawn);
            timeAfterSpawn = 0;

            GameObject bullet1 = Instantiate(E, gosegu.transform.position, transform.rotation);
            GameObject bullet2 = Instantiate(E, Vichan.transform.position, transform.rotation);
        }
    }
}
