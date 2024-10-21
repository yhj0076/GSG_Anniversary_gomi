using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_rains : MonoBehaviour
{
    public bool end;
    // Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 8f;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y <= -30.2f&&end==false)
        {
            transform.localPosition = new Vector2(0,14.9f);
            int count = transform.childCount;
            for(int i = 0; i<count; i++)
            {
                if(transform.GetChild(i).gameObject.activeSelf == false)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnDisable()
    {
        if (transform.name == "raindrops")
        {
            transform.localPosition = new Vector2(0, 34.4f);
        }
        else
        {
            transform.localPosition = new Vector2(0, 11.5f);
        }
    }
}
