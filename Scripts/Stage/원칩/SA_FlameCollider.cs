using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_FlameCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "쥬시쿠루_0(Clone)"||collision.transform.tag == "Player")
        {
            if(collision.transform.tag == "Player")
            {
                collision.GetComponent<SA_HealthController>().Damaged();
            }
            gameObject.SetActive(false);
        }
    }
}
