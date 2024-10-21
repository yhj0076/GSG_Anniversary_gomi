using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Axe : MonoBehaviour
{
    public float startAngle;
    public float endAngle;
    public float speed;

    float time;
    private void OnEnable()
    {
        time = 0;
        transform.localRotation = Quaternion.Euler(0,0,startAngle);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        if(startAngle < endAngle)
        {
            if (startAngle + time < endAngle)
            {
                transform.localRotation = Quaternion.Euler(0, 0, startAngle + time);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, endAngle);
                gameObject.SetActive(false);
            }
        }
        else if(startAngle > endAngle)
        {
            if (startAngle - time > endAngle)
            {
                transform.localRotation = Quaternion.Euler(0, 0, startAngle - time);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, endAngle);
                gameObject.SetActive(false);
            }
        }
    }
}
