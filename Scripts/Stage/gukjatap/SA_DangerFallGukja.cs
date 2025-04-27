using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DangerFallGukja : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Player.transform.position.x, transform.position.y);
        if (transform.parent.GetComponent<SA_Nadaejima>().gukjaCount==5)
        {
            transform.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        transform.position = new Vector2(Player.transform.position.x, transform.position.y);
    }
}
