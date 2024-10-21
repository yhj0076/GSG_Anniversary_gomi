using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_TutoPill : MonoBehaviour
{
    GameObject tuto;
    // Start is called before the first frame update
    void Start()
    {
        tuto = GameObject.Find("Tutorial");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<SA_HealthController>().health += 1;
            SA_UIManager.instance.healthCheck(collision.GetComponent<SA_HealthController>().health);
            if (transform.name == "rightP(Clone)")
            {
                tuto.GetComponent<SA_Tutorial>().rightClear = true;
                collision.transform.GetChild(1).gameObject.SetActive(false);
                collision.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (transform.name == "leftP(Clone)")
            {
                tuto.GetComponent<SA_Tutorial>().leftClear = true;
                collision.transform.GetChild(2).gameObject.SetActive(false);
                collision.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (transform.name == "Jump1P(Clone)")
            {
                tuto.GetComponent<SA_Tutorial>().Jump1Clear = true;
                collision.transform.GetChild(3).gameObject.SetActive(false);
                collision.transform.GetChild(4).gameObject.SetActive(true);
            }
            else if (transform.name == "Jump2P(Clone)")
            {
                tuto.GetComponent<SA_Tutorial>().Jump2Clear = true;
                collision.transform.GetChild(4).gameObject.SetActive(false);
            }
        }
        Destroy(gameObject);
    }
}
