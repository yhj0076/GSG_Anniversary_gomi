using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_HurtObstacleWithCol : MonoBehaviour
{
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<SA_HealthController>().Damaged();
        }
    }
}
