using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_fizznicoHeyHeySwing : MonoBehaviour
{
    float time = 0;
    bool StageOn = false;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (StageOn)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, -5.5f), 0.1f);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, -7.5f), 0.1f);
        }

        if(time>=2)
        {
            transform.rotation = Quaternion.Euler(0,0,Mathf.Sin((time-2)*1.3f)*10);
        }

        if(time >= 31.6f)
        {
            StageOn = false;
        }
    }

    private void OnEnable()
    {
        StageOn = true;
        time = 0;
    }
    private void OnDisable()
    {
        StageOn = true;
        time = 0;
        transform.position = new Vector2(transform.position.x, -7.5f);
        transform.rotation = Quaternion.Euler(0,0,0);
    }
}
