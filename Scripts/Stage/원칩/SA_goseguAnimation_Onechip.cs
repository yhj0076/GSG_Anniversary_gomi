using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_goseguAnimation_Onechip : MonoBehaviour
{
    Animator anime;
    public bool timer = false;
    public GameObject cam;
    float time = 0;

    float DamageTime = 0;
    // Update is called once per frame
    void Update()
    {
        if(timer)
        {
            time += Time.deltaTime;
            anime.SetFloat("Time",time);
        }
        else
        {
            time = 0;
        }

        if(anime.GetCurrentAnimatorStateInfo(0).IsName("OneChip_WTF"))
        {
            DamageTime += Time.deltaTime;
            if(DamageTime < 0.5f)
            {
                transform.parent.GetChild(3).gameObject.SetActive(true);
                cam.GetComponent<SA_CamShake>().Shake = true;
            }
            else
            {
                transform.parent.GetChild(3).gameObject.SetActive(false);
                cam.GetComponent<SA_CamShake>().Shake = false;
            }
        }
        else
        {
            DamageTime = 0;
        }
    }

    private void OnEnable()
    {
        anime = GetComponent<Animator>();
        anime.SetFloat("Time",0);
        time = 0;
    }
}
