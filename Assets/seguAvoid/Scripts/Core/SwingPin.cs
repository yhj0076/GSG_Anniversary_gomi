using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPin : MonoBehaviour
{
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*3;
        transform.rotation = Quaternion.Euler(0,0,Mathf.Sin(time)*20);
    }
}
