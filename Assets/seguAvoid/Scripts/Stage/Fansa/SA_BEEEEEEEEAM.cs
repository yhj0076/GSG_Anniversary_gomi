using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_BEEEEEEEEAM : MonoBehaviour
{
    public float startAngle1;
    public float startAngle2;
    public float endAngle1;
    public float endAngle2;
    public float speed;

    float startAngle;
    float endAngle;

    float time;
    public bool Beam;
    private void OnEnable()
    {
        time = 0;
        Beam = false;
        if (Random.Range(0, 2) == 0)
        {
            startAngle = startAngle1;
            endAngle = endAngle1;
        }
        else
        {
            startAngle = startAngle2;
            endAngle = endAngle2;
        }
        transform.localRotation = Quaternion.Euler(0, 0, startAngle);
    }
    // Update is called once per frame
    void Update()
    {
        if (Beam)
        {
            time += Time.deltaTime * speed;
            if (startAngle < endAngle)
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
            else if (startAngle > endAngle)
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
}
