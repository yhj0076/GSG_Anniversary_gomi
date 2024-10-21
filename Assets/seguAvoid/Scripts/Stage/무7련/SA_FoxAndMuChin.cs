using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_FoxAndMuChin : MonoBehaviour
{
    public float X;
    public float Y;
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(X,Y));
    }
}
