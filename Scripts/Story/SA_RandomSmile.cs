using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_RandomSmile : MonoBehaviour
{
    Animator anime;

    float time = 0;
    float changeTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= changeTime)
        {
            changeTime = Random.Range(1,5);
            anime.SetBool("WHAT",true);
            Invoke("wait",0.08f);
            time = 0;
        }
    }

    void wait()
    {
        anime.SetBool("WHAT",false);
    }
}
