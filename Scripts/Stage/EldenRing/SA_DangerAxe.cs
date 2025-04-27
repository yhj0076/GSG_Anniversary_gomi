using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DangerAxe : MonoBehaviour
{
    public GameObject axe;

    // Update is called once per frame
    void Update()
    {
        if (axe.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
