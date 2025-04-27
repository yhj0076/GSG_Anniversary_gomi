using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Motto : MonoBehaviour
{
    public Vector2 destination;
    Vector2 FirstPos;
    float time = 0;

    Vector2 minus;
    private void Start()
    {
        FirstPos = transform.localPosition;
        minus = destination - FirstPos;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*5;
        if (time < Mathf.PI)
        {
            transform.localPosition = FirstPos + minus*Mathf.Sin(time);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        time = 0;
    }
}
