using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SA_AddedScore : MonoBehaviour
{
    Text text;

    float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.color = new Color(0, 0.6352941f,1,Mathf.Cos(time));
        if(time>Mathf.PI/2)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        text = GetComponent<Text>();
        time = 0;
    }
}
