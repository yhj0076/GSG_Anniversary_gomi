using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Arrow : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "Player")
        {
            collision.transform.GetComponent<SA_HealthController>().Damaged();
            Destroy(gameObject);
        }
        else if(collision.transform.name == "Platform")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}
