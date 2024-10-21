using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_TurtleBackMove : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down*5;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Platform")
        {
            player = GameObject.Find("Player");
            if(transform.position.x > player.transform.position.x)
            {
                rigid.velocity = Vector2.left*5;
            }
            else if(transform.position.x < player.transform.position.x)
            {
                rigid.velocity = Vector2.right*5;
            }
            Destroy(gameObject,5);
        }
        
        if(collision.name == "Player")
        {
            collision.GetComponent<SA_PlayerController>().ZhonyaTrue();
            Destroy(gameObject);
        }
    }
}
