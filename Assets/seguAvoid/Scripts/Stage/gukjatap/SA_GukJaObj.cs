using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_GukJaObj : MonoBehaviour
{
    AudioSource soundPlayer;
    GameObject spawner;
    Rigidbody2D rigid;

    public Sprite safe;
    SpriteRenderer render;
    bool kkang = true;

    private void Start()
    {
        spawner = FindObjectOfType<SA_Nadaejima>().gameObject;
        soundPlayer = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        kkang = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (kkang && (collision.transform.name == "국자(Clone)" || collision.transform.name == "Platform" || collision.transform.name == "국자 1(Clone)"))
        {
            soundPlayer.Play();
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            render.sprite = safe;
            Destroy(GetComponent<SA_HurtObstacleWithCol>());
            kkang = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawner.GetComponent<SA_Nadaejima>().GukJa == false)
        {
            Destroy(gameObject);
        }
    }
}
