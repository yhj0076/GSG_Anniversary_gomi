using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SA_FadeOut : MonoBehaviour
{
    public Text text;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.color = new Color(text.color.r,text.color.g,text.color.b,Mathf.Sin(time));
        if(time>Mathf.PI)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        time = 0;
    }
}
