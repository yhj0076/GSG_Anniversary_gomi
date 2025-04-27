using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_LastGukja : MonoBehaviour
{
    GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<SA_Nadaejima>().gameObject;
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 30;
    }

    void Update()
    {
        if (spawner.GetComponent<SA_Nadaejima>().GukJa == false)
        {
            Destroy(gameObject);
        }
    }
}
