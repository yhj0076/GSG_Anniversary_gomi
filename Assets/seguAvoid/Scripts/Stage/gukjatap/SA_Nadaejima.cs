using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Nadaejima : MonoBehaviour
{
    public bool GukJa = false;
    public GameObject gukJaObj1;
    public GameObject gukJaObj2;
    public GameObject OB;
    public GameObject Siling;
    public GameObject Player;
    public GameObject LastGukja;
    public GameObject DangerZone;
    AudioSource soundPlayer;
    public AudioClip kkang;

    Vector3 lastCamPos;
    Vector2 camPos;
    float time = 0;
    float stageTime = 0;
    public int gukjaCount = 0;
    public bool Paused;
    public bool FirstSoundEnd;
    private void OnEnable()
    {
        Paused = false;
        FirstSoundEnd = false;
        //OB.GetComponent<SA_OutOfBound>().DamageOn = true;
        soundPlayer = GetComponent<AudioSource>();
        time = 1.9f;
        stageTime = 0;
        gukjaCount = 0;
        soundPlayer.Play();
        GukJa = true;
        //Siling.SetActive(false);
        Invoke("InvokeDanger",2.9f);
    }

    void InvokeDanger()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(soundPlayer.isPlaying == false && Paused == false)
        {
            FirstSoundEnd = true;
        }
        if (FirstSoundEnd)
        {
            time += Time.deltaTime;
            stageTime += Time.deltaTime;
        }
        if(time >= 2)
        {
            int choice = Random.Range(0, 2);
            if (gukjaCount < 5)
            {
                if (choice == 0)
                {
                    var kang = GameObject.Instantiate(gukJaObj1, new Vector2(Player.transform.position.x, transform.position.y + 1), Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    kang.transform.parent = transform;
                    gukjaCount++;
                }
                else
                {
                    var kang = GameObject.Instantiate(gukJaObj2, new Vector2(Player.transform.position.x, transform.position.y + 1), Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    kang.transform.parent = transform;
                    gukjaCount++;
                }

                if (gukjaCount == 4)
                {
                    DangerZone.SetActive(true);
                }
            }
            else
            {
                GameObject.Instantiate(LastGukja, new Vector2(-13.14f, -2.9f), Quaternion.Euler(0, 0, 90));
                DangerZone.SetActive(false);
            }
            time = 0;
        }

        if(stageTime >= 12)
        {
            GukJa = false;
            gameObject.SetActive(false);
        }
    }

    

    private void OnDisable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        Siling.SetActive(true);
        int lastIndex = transform.childCount-1;
        for(int i = lastIndex; i > 1; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        CancelInvoke("InvokeDanger");
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
