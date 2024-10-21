using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_BossGukja : MonoBehaviour
{
    AudioSource soundPlayer;
    GameObject spawner;
    Rigidbody2D rigid;

    public Sprite safe;
    SpriteRenderer render;
    bool kkang = true;

    private void Start()
    {
        spawner = transform.parent.gameObject;
        soundPlayer = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        kkang = true;
        rigid.AddForce(new Vector2(0,-20),ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (kkang && (collision.transform.name == "국자(Clone)" || collision.transform.name == "Platform" || collision.transform.name == "국자 1(Clone)"))
        {
            soundPlayer.Play();
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            render.sprite = safe;
            kkang = false;
        }
    }
}
