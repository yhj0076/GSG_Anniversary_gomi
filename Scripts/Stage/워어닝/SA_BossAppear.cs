using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class SA_BossAppear : MonoBehaviour
{
    float time = 0;
    float delayTime = 0;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        //float check = (Mathf.Cos(time)/2*-1)+(1/2);
        if (time<Mathf.PI)
        {
            time += Time.deltaTime*speed;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1, ((Mathf.Cos(time) / 2) * -1)*2);
        }
        else if(time >= Mathf.PI && delayTime < 0.5f){
            delayTime += Time.deltaTime*speed;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else if(delayTime>=0.5f && time < Mathf.PI*2)
        {
            time += Time.deltaTime*speed;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, ((Mathf.Cos(time) / 2 * -1)*2));
        }
        else if(time >= Mathf.PI*2)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        time = 0;
        delayTime = 0;
    }

    private void OnDisable()
    {
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
