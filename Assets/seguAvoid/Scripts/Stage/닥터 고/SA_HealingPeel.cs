using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_HealingPeel : MonoBehaviour
{
    public int heal;
    public AudioClip heel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<SA_HealthController>().Heal();
            GetComponent<AudioSource>().PlayOneShot(heel);
        }
        Destroy(gameObject);
    }
}
