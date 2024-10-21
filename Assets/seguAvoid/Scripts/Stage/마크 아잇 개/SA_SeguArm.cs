using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_SeguArm : MonoBehaviour
{
    public int orbit;           // 몇 바퀴 돌리냐
    public float radius;        // 반지름
    public float speed;         // 속도
    public GameObject Center;   // 중앙

    float time = 0;
    float StopTime = 0;
    public float NowSpinTimes = 0;
    public bool stop = false;

    float time2 = 0;

    private void OnEnable()
    {
        time = 0f;
        StopTime = 0f;
        NowSpinTimes = 0;
        time2 = 0;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        time2 += Time.deltaTime;
        if (time2>=transform.parent.parent.GetComponent<SA_WTF>().delayTime)
        {
            StopTime += Time.deltaTime;
            if (StopTime >= Mathf.PI / speed * 2)
            {
                NowSpinTimes++;
                StopTime = 0;
            }

            if (NowSpinTimes < orbit)
            {
                SpinArm();
            }
            else
            {
                StopArm();
            }
        }
    }
    
    void SpinArm()
    {
        time += Time.deltaTime * speed;
        transform.position = new Vector2(Center.transform.position.x + radius * Mathf.Cos(time), Center.transform.position.y + radius * Mathf.Sin(time));
    }

    void StopArm()
    {
        stop = true;
        transform.position = new Vector2(transform.position.x,transform.position.y);
    }
}
