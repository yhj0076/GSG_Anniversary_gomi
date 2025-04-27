using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_floorRight_Little : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rigid;
    public float rightSp;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(transform.position.x, Player.transform.position.y+0.8f);
        rigid.velocity = Vector2.right * rightSp;
        Invoke("disableObj", 1.5f);
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector2(-9.92f, -3.447706f);
    }

    void disableObj()
    {
        gameObject.SetActive(false);
    }
}
