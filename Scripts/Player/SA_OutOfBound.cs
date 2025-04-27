using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_OutOfBound : MonoBehaviour
{
    public GameObject Player;
    public bool DamageOn = false;
    private void Start()
    {
        DamageOn = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (DamageOn)
        {
            Player.GetComponent<SA_HealthController>().Damaged();
            Player.transform.position = new Vector2(transform.position.x, transform.position.y - 3);
            Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
