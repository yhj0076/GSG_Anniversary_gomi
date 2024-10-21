using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_sky_Big : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        /*time += Time.deltaTime;
        transform.localPosition = new Vector2(transform.localPosition.x,14.73f-14.73f*Mathf.Sin(time));
        if(time >= Mathf.PI)
        {
            gameObject.SetActive(false);
        }*/
        if (transform.localPosition.y <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 12;
        }
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 12;
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector2(transform.localPosition.x,14.73f);
    }
}
