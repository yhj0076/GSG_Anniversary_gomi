using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 왼쪽으로 움직임.
public class SA_floorLeft_Little : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rigid;
    public float leftSp;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(transform.position.x, Player.transform.position.y+0.8f);
        rigid.velocity = Vector2.left * leftSp;
        Invoke("disableObj",1.5f);
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector2(9.92f,-3.447706f);
    }

    void disableObj()
    {
        gameObject.SetActive(false);
    }
}
