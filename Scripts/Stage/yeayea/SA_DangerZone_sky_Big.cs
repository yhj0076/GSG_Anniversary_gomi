using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DangerZone_sky_Big : MonoBehaviour
{
    public int index;
    void Update()
    {
        falseObj(index);
    }

    void falseObj(int index)
    {
        if (transform.parent.GetChild(index).gameObject.activeSelf == true)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
