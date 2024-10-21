using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_OneChipPlatform : MonoBehaviour
{
    Collider2D col;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y-0.5f >= Player.transform.position.y)
        {
            col.isTrigger = true;
        }
        else
        {
            col.isTrigger = false;
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        col.isTrigger = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            col.isTrigger = false;
        }
    }*/
}
