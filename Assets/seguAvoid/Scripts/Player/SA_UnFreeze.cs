using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_UnFreeze : MonoBehaviour
{
    float time = 0;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 0.1f)
        {
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            time = 0;
        }
    }
}
