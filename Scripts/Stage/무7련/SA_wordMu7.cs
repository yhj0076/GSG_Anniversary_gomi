using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_wordMu7 : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject,1f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,new Vector2(-20,transform.position.y),speed*Time.deltaTime);
    }
}
