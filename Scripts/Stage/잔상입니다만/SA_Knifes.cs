using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Knifes : MonoBehaviour
{

    /*
     GameObject Player;
    Rigidbody2D rigid;
    protected Vector2 beforePos;
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        transform.rotation = Quaternion.LookRotation(Player.transform.position);
        beforePos = transform.position;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        transform.position = beforePos;
    }
     */
    // Start is called before the first frame update
    public float speed;
    public bool StageOn;
    GameObject Player;
    protected Vector2 beforePos;
    Vector2 dir;
    private void OnEnable()
    {
        beforePos = transform.position;
        Player = GameObject.Find("Player");
        dir = (Vector2)Player.transform.position - beforePos;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle+180);
        transform.GetChild(0).position = Player.transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.GetChild(0).position, speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        transform.position = beforePos;
    }
}
