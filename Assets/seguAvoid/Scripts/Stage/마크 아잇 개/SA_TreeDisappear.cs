using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_TreeDisappear : MonoBehaviour
{
    private void Update()
    {
        if (transform.parent.GetChild(0).GetComponent<SA_SeguArm>().stop)
        {
            this.gameObject.SetActive(false);
        }
    }
}
