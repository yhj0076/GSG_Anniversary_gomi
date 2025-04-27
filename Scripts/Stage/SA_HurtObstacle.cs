using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_HurtObstacle : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SA_HealthController player = collision.GetComponent<SA_HealthController>();

            if (player != null)
            {
                player.Damaged();
            }
        }
    }
}
