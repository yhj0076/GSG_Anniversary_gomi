using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_HurtForLast : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SA_HealthController player = collision.GetComponent<SA_HealthController>();

            if (player != null)
            {
                player.Damaged();
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
