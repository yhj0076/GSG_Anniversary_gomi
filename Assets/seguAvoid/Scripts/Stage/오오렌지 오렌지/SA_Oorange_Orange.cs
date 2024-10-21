using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Oorange_Orange : MonoBehaviour
{
    public GameObject orange1;
    public GameObject orange2;

    // 0.0초 1단 오렌지
    // 3.8초 2단 오렌지
    // 7.2초 3단 오렌지
    // 10.8초 4단 오렌지
    // 13.3초 왕 오렌지
    private void OnEnable()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(GenLeftOrange(0.7f,0,new Vector2(11,0)));
        StartCoroutine(GenLeftOrange(1f,3.8f,new Vector2(-11,0)));
        StartCoroutine(GenLeftOrange(1.5f,7.2f,new Vector2(11,0)));
        StartCoroutine(GenLeftOrange(2,10.8f,new Vector2(-11,0)));
        StartCoroutine(GenLeftOrange(3,13.3f,new Vector2(0,10)));
    }

    IEnumerator GenLeftOrange(float size,float delayTime,Vector2 pos)
    {
        yield return new WaitForSeconds(delayTime);
        if (Random.Range(0, 2) == 1)
        {
            var Oorange1 = GameObject.Instantiate(orange1, pos, Quaternion.identity);
            Oorange1.transform.parent = transform;
            Oorange1.transform.localScale = new Vector3(size, size, 0);
            if (pos.x > 0)
            {
                Oorange1.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3* (size / 0.7f), 3),ForceMode2D.Impulse);
            }
            else if(pos.x < 0)
            {
                Oorange1.GetComponent<Rigidbody2D>().AddForce(new Vector2(3*(size/0.7f), 3), ForceMode2D.Impulse);
            }
            else
            {
                Oorange1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -15), ForceMode2D.Impulse);
            }
        }
        else
        {
            var Oorange2 = GameObject.Instantiate(orange2, pos, Quaternion.identity);
            Oorange2.transform.parent = transform;
            Oorange2.transform.localScale = new Vector3(size, size, 0);
            if (pos.x > 0)
            {
                Oorange2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3* (size / 0.7f), 3), ForceMode2D.Impulse);
            }
            else if(pos.x < 0)
            {
                Oorange2.GetComponent<Rigidbody2D>().AddForce(new Vector2(3* (size / 0.7f), 3), ForceMode2D.Impulse);
            }
            else
            {
                Oorange2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -15), ForceMode2D.Impulse);
            }
        }
        StopCoroutine("GenLeftOrange");
    }

    private void Update()
    {
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        for(int i = 0; i < 5; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
