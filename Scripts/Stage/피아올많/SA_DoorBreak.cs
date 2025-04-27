using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DoorBreak : MonoBehaviour
{
    Animator anime;
    Rigidbody2D rigid;

    public bool kick;

    private void Awake()
    {
        anime = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        transform.localPosition = new Vector2(7.700729f, -2.24f);
        kick = false;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (kick)
        {
            anime.SetBool("isKicked",true);
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.AddForce(new Vector2(-200,80));
            kick = false;
        }

        if (anime.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        anime.SetBool("isKicked", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            collision.gameObject.GetComponent<SA_HealthController>().Damaged();
        }
    }
}
