using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Liver : MonoBehaviour
{
    private void Start()
    {
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            transform.parent.GetComponent<SA_BossHealth>().Hurt();
            transform.parent.parent.GetComponent<SA_BossStageController>().LiverGen_time = 0;
            transform.parent.parent.GetComponent<SA_BossStageController>().existLiver = false;
            Destroy(gameObject);
        }

        if(collision.name == "Platform")
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
