using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_creamBread : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public float changeSpeed;
    float time = 0;
    Vector3 firstScale;
    Vector2 firstPos;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*changeSpeed;
        transform.localScale = new Vector2((0.75f - (Mathf.Sin(time) * 0.25f))*firstScale.x, (1 + (Mathf.Sin(time) * 0.5f))*firstScale.y); //1~0.5 0.5~1.5
    }

    private void OnEnable()
    {
        firstPos = transform.localPosition;
        rigid = GetComponent<Rigidbody2D>();
        time = 0;
        rigid.AddForce(Vector2.left * speed,ForceMode2D.Impulse);
        firstScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
    }

    private void OnDisable()
    {
        transform.localPosition = firstPos;
        transform.localScale = firstScale;
        rigid.velocity = Vector2.zero;
    }
}
