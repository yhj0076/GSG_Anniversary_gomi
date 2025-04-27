using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DangerZone_floor_Little : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Player.transform.position.y+0.8f);
        if (transform.parent.GetChild(4).gameObject.activeSelf == true)
        {
            transform.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        transform.position = new Vector2(transform.position.x, Player.transform.position.y+3.2f);
    }
}
