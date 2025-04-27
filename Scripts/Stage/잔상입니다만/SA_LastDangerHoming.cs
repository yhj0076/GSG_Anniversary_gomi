using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_LastDangerHoming : MonoBehaviour
{
    GameObject Player;
    protected Vector2 beforePos;
    Vector2 dir;
    private void OnEnable()
    {
        Player = GameObject.Find("Player");
        homing();
    }

    void homing()
    {
        dir = ((Vector2)Player.transform.position+new Vector2(0,0.5f)) - (Vector2)transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle-90);
        transform.GetChild(1).position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetChild(5).gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            homing();
        }
    }
}
