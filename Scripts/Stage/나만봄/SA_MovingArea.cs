using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_MovingArea : MonoBehaviour
{
    public bool moving;
    private void OnEnable()
    {
        moving = true;
        transform.localPosition = new Vector2(Random.Range(-7f, 7f), 0);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        if (Random.Range(0, 2) == 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * 7;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * 7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((Mathf.Abs(transform.localPosition.x) > 7.55f)&&moving)
        {
            if (transform.localPosition.x > 7.55f)
            {
                transform.localPosition = new Vector2(7.55f,0);
            }
            else if (transform.localPosition.x < -7.55f)
            {
                transform.localPosition = new Vector2(-7.55f, 0);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x*-1,0);
        }
        else if(moving == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
