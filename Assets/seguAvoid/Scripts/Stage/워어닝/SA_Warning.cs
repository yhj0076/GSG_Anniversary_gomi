using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Warning : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-3,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x <= -11.83f)
        {
            transform.localPosition = new Vector2(12.276f,transform.localPosition.y);
        }
    }
}
