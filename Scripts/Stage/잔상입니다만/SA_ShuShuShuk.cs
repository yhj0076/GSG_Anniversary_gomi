using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_ShuShuShuk : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    protected bool StageOn = false;
    protected float time = 0;
    protected Vector2 destination;
    protected Vector2 beforePos;

    // Update is called once per frame
    public void Update()
    {
        if(StageOn)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition,destination,0.08f);
        }
        else
        {
            
            time += Time.deltaTime;
            if (time <= Mathf.PI / 2)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                spriteRenderer.color = new Color(1, 1, 1, Mathf.Cos(time));
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 0);
                gameObject.SetActive(false);
            }
        }
    }
    private void OnEnable()
    {
        StageOn = true;
        beforePos = transform.localPosition;
        time = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1,1,1,1);
        Invoke("Knives",0.08f);
        switch(gameObject.name)
        {
            case "Jansang_BR":
                destination = new Vector2(7.5f,-2.81f);
                break;
            case "Jansang_BL":
                destination = new Vector2(-7f, -2.81f);
                break;
            case "Jansang_TR":
                destination = new Vector2(7.5f, 3.75f);
                break;
            case "Jansang_TL":
                destination = new Vector2(-7f, 3.75f);
                break;
        }
        Invoke("delay_StageOff",1);
    }

    protected void delay_StageOff()
    {
        StageOn = false;
    }

    private void OnDisable()
    {
        transform.localPosition = beforePos;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
    }

    void Knives()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
    }
}
