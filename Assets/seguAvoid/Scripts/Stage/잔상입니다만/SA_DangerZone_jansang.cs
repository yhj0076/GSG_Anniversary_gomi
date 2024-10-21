using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DangerZone_jansang : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float time = 0;
    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1,1,1,0);
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime*(Mathf.PI*1f);
        if (time < Mathf.PI)
        {
            spriteRenderer.color = new Color(1, 1, 1, Mathf.Sin(time) / 2);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
