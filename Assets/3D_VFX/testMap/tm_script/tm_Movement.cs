using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tm_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 11.5f; // default : 11.5f
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveforward();
    }

    void moveforward()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
    }
}
