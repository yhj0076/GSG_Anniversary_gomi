using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Germ : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1,15),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(7,transform.GetComponent<Rigidbody2D>().velocity.y);
    }
}
