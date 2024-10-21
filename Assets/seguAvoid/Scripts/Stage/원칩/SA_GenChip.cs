using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_GenChip : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,2);
    }
    private void Update()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(-6.41f, -2.068301f),5*Time.deltaTime);
    }
}
