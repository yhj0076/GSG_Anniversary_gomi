using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Knife : MonoBehaviour
{
    public float speed;
    public bool StageOn;
    protected Vector2 beforePos;
    private void OnEnable()
    {
        beforePos = transform.position;
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
