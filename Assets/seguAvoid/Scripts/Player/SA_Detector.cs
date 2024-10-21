using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Detector : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            transform.parent.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
