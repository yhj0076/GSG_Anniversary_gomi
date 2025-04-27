using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Bullet : MonoBehaviour
{
    public GameObject start;
    public float speed;
    public int damage;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = (FindObjectOfType<SA_PlayerController>().transform.position - start.transform.position)*speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SA_HealthController player = collision.GetComponent<SA_HealthController>();

            if(player != null)
            {
                player.Damaged();
            }
        }
        if(collision.gameObject.layer != 10)
        {
            Destroy(gameObject);
        }
    }
}
