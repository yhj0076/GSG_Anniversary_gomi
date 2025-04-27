using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_pickleGen : MonoBehaviour
{
    public GameObject pickle;
    public int howmany;
    private void OnEnable()
    {
        for(int i = 0; i < howmany; i++)
        {
            GameObject.Instantiate(pickle, transform.localPosition, Quaternion.identity).transform.parent = transform;
        }
    }
    private void OnDisable()
    {
        for(int i = 0; i < howmany; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
