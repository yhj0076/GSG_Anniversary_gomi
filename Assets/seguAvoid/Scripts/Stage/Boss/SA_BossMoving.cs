using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_BossMoving : MonoBehaviour
{
    float time;
    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<SA_BossStageController>().state == SA_BossStageController.BOSS_STATE.BOSS_START)
        {
            hello();
        }
        else if(transform.GetComponentInParent<SA_BossStageController>().state == SA_BossStageController.BOSS_STATE.BOSS_DEFEAT)
        {
            bye();
        }
        else
        {
            time = 0;
        }
    }

    private void OnEnable()
    {
        time = 0;
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        transform.localScale = new Vector3(1f,1f,1f);
    }

    void hello()
    {
        time += Time.deltaTime;
        /*float cosGraph = Mathf.Cos(time + Mathf.PI) + 1;
        if (cosGraph<1f)
        {
            transform.localScale = new Vector3(0.7f+ (cosGraph*3/7), 0.7f+ ((Mathf.Cos(time + Mathf.PI) + 1)*3/7), 0.7f+ ((Mathf.Cos(time + Mathf.PI) + 1)*3/7));
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Cos(time + Mathf.PI) + 1);
        }
        else if(Mathf.Cos(time + Mathf.PI) + 1 >= 1f)
        {
            transform.localScale = new Vector3(1,1,1);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            transform.parent.GetComponent<SA_BossStageController>().state = SA_BossStageController.BOSS_STATE.BOSS_FIGHTING;
        }*/
    }

    void bye()
    {
        time += Time.deltaTime;
        if (Mathf.Cos(time) > 0)
        {
            //transform.localScale = new Vector3(0.7f + (Mathf.Cos(time)*3/10), 0.7f + (Mathf.Cos(time)*3/10), 0.7f + (Mathf.Cos(time)*3/10));
        }
        else if (Mathf.Cos(time) <= 0)
        {
            //transform.localScale = new Vector3(0.7f, 0.7f, 0);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
