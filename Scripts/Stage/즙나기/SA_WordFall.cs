using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_WordFall : MonoBehaviour
{
    Rigidbody2D rigid;
    public float downSp;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.down * downSp,ForceMode2D.Impulse);
        Destroy(gameObject,1.4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Platform")
        {
            Destroy(gameObject);
        }
    }

    // private void Update()
    // {
    //     if (transform.localPosition.y < -13)
    //     {
    //         disableObj();
    //     }
    // }
    // 
    // void disableObj()
    // {
    //     gameObject.SetActive(false);
    // }
}
