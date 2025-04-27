using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Flame : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localPosition = new Vector2(-0.54f,0);
        for(int i = 0; i < 11; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.right*30;
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector2(-0.54f, 0);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
