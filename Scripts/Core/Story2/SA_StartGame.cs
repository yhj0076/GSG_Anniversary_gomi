using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_StartGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SA_GameManager.instance.GameStart();
    }
}
