using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_SpinX : MonoBehaviour
{
    public bool spin;

    float time;

    private void OnEnable()
    {
        time = 45;
        spin = false;
        transform.rotation = Quaternion.Euler(0, 0, time);
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            time -= Time.deltaTime*50;
            transform.rotation = Quaternion.Euler(0, 0, time);
        }
    }
}
