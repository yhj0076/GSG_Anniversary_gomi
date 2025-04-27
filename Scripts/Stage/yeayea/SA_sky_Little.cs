using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 무조건 플레이어 머리 위로 떨어짐

public class SA_sky_Little : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rigid;
    public float downSp;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Player.transform.position.x,transform.position.y);
        rigid.velocity = Vector2.down * downSp;
        Invoke("disableObj",1.5f);
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector2(-3,7.48f);
    }

    void disableObj()
    {
        gameObject.SetActive(false);
    }
}
