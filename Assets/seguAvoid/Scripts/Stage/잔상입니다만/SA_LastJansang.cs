using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_LastJansang : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool StageOn = false;
    float time = 0;
    Vector2 destination;
    Vector2 beforePos;
    private void OnEnable()
    {
        StageOn = true;
        beforePos = transform.localPosition;
        time = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 1);
        destination = new Vector2(0, 3.91f);
        Invoke("InvokeEnable",1.5f);
        transform.GetChild(6).gameObject.SetActive(true);
    }

    public void Update()
    {
        if (StageOn)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, destination, 0.08f);
        }
        else
        {

            time += Time.deltaTime*1.3f;
            if (time <= Mathf.PI / 2)
            {
                spriteRenderer.color = new Color(1, 1, 1, Mathf.Cos(time));
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 0);
                gameObject.SetActive(false);
            }
        }
    }

    void InvokeEnable()
    {
        Invoke("delayKnife1", 0.2f);
        Invoke("delayKnife2", 0.4f);
        Invoke("delayKnife3", 0.6f);
        Invoke("delayKnife4", 0.8f);
        Invoke("delayKnife5", 1.1f);
        Invoke("delayKnife6", 1.3f);
    }

    void delayKnife1()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void delayKnife2()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }
    void delayKnife3()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }
    void delayKnife4()
    {
        transform.GetChild(3).gameObject.SetActive(true);
    }
    void delayKnife5()
    {
        transform.GetChild(4).gameObject.SetActive(true);
    }
    void delayKnife6()
    {
        transform.GetChild(5).gameObject.SetActive(true);
        StageOn = false;
    }

    private void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(5).gameObject.SetActive(true);
    }
}
