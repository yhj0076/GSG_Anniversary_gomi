using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SA_Tutorial : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject Tip;

    public bool leftClear;
    public bool rightClear;
    public bool Jump1Clear;
    public bool Jump2Clear;

    bool leftGen;
    bool rightGen;
    bool Jump1Gen;
    bool Jump2Gen;
    float time = 0;
    float delayTime = 0;
    // Update is called once per frame
    void Update()
    {
        if(rightGen == false)
        {
            GameObject.Instantiate(point1, new Vector2(8.1f,-3.85f),Quaternion.identity);
            rightGen = true;
        }
        else if (leftGen == false && rightClear)
        {
            GameObject.Instantiate(point2, new Vector2(-8.1f, -3.85f), Quaternion.identity);
            leftGen = true;
        }
        else if (Jump1Gen == false && leftClear)
        {
            GameObject.Instantiate(point3, new Vector2(0f, -1f), Quaternion.identity);
            Jump1Gen = true;
        }
        else if (Jump2Gen == false && Jump1Clear)
        {
            GameObject.Instantiate(point4, new Vector2(0f, 1f), Quaternion.identity);
            Jump2Gen = true;
        }
        else if (Jump2Clear)
        {
            if (time < Mathf.PI / 2)
            {
                if (delayTime < 1)
                {
                    delayTime += Time.deltaTime;
                    transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                }
                else
                {
                    time += Time.deltaTime;
                    transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, Mathf.Cos(time));
                }
            }
            else
            {
                transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                Invoke("delayFalse", 0.1f);
                Jump2Clear = false;
            }
        }
    }

    void delayFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        leftClear = false;
        rightClear = false;
        Jump1Clear = false;
        Jump2Clear = false;

        leftGen   = false;
        rightGen  = false;
        Jump1Gen  = false;
        Jump2Gen = false;
        time = 0;
        delayTime = 0;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
