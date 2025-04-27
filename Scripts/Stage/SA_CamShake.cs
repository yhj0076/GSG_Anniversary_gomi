using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_CamShake : MonoBehaviour
{
    public bool Shake = false;

    Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        camPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Shake)
        {
            transform.position = new Vector3(camPos.x+Random.Range(-0.2f,0.2f), camPos.y + Random.Range(-0.2f, 0.2f),camPos.z);
        }
        else
        {
            transform.position = camPos;
        }
    }
}
