using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Arm : MonoBehaviour
{
    public bool Atk;

    public GameObject Fox;
    public GameObject RRtan;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Atk = false;
        time = 0;
    }

    // Update is called once per frame
    /*void Update()
    {
        


        if (Atk)
        {
            time += Time.deltaTime;
            if(time >2)
            {
                if (transform.name == "Left_Idle_0")
                {
                    var fox = GameObject.Instantiate(Fox, transform.GetChild(0).position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    fox.transform.parent = transform.parent.parent;
                    fox.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -3));
                }
                else
                {
                    var rr = GameObject.Instantiate(RRtan, transform.GetChild(0).position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                    rr.transform.parent = transform.parent.parent;
                    rr.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -3));
                }
                time = 0;
            }
        }
        else
        {
            time = 0;
        }
    }*/

    public void gen()
    {
        
        if (transform.name == "Left_Idle_0")
        {
            var fox = GameObject.Instantiate(Fox, transform.GetChild(0).position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            fox.transform.parent = transform;
        }
        else
        {
            var rr = GameObject.Instantiate(RRtan, transform.GetChild(0).position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            rr.transform.parent = transform;
        }
    }

    public void delete()
    {
        if (transform.childCount == 2)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
    }
}
