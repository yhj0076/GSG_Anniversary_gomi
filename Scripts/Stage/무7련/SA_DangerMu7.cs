using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DangerMu7 : MonoBehaviour
{
    public GameObject Player;
    public bool stop;
    // Update is called once per frame

    private void OnEnable()
    {
        stop = false;
        transform.localPosition = new Vector2(transform.position.x, -3.2f);
    }
}
