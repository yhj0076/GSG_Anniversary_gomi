using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SA_HowManyTry : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = (SecurityPlayerPrefs.GetInt("SA_SeguDiedCount",0)+1)+"트";
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < Mathf.PI / 2)
        {
            GetComponent<Text>().color = new Color(1,1,1,Mathf.Cos(time));
        }
        else
        {
            GetComponent<Text>().color = new Color(1, 1, 1, 0);
            gameObject.SetActive(false);
        }
    }
}
