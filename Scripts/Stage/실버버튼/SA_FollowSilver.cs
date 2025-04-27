using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_FollowSilver : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid;
    public bool go;
    public float speed;
    public int thisIndex;
    Vector3 beforePos;
    Vector2 normal;
    // Start is called before the first frame update
    void OnEnable()
    {
        beforePos = transform.position;
        player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        normal = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            if (thisIndex + 1 < transform.parent.childCount)
            {
                transform.parent.GetChild(thisIndex + 1).GetChild(0).gameObject.SetActive(true);
            }
            normal = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            rigid.constraints = RigidbodyConstraints2D.None;
            go = false;
        }
        else{

        }
        rigid.velocity = new Vector2(normal.normalized.x, normal.normalized.y) * speed;
    }

    private void OnDisable()
    {
        transform.position = beforePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
