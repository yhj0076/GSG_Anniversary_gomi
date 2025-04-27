using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_ItalianBLT : MonoBehaviour
{
    public bool drop = false;

    private void OnEnable()
    {
        drop = false;
        transform.GetChild(0).localPosition = new Vector2(-2.12f,0);
        transform.GetChild(1).localPosition = new Vector2(2.12f,0);
        transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        transform.GetChild(1).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (drop)
        {
            randomDrop();
            drop = false;
        }
    }

    void randomDrop()
    {
        if (Random.Range(0, 2) == 0)
        {
            transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            transform.GetChild(1).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        Invoke("offObj",2);
    }

    void offObj()
    {
        gameObject.SetActive(false);
    }
}
