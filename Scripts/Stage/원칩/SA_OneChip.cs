using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_OneChip : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject chip;
    public GameObject SAFE;
    float time = 0;
    float safeTime = 0;
    public float wait;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*speed;
        if(time >= Mathf.PI/2 && time < Mathf.PI / 2 + wait)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
        else if(time >= Mathf.PI/2+wait&& time - wait < Mathf.PI)
        {
            safeTime += Time.deltaTime * speed;
            spriteRenderer.color = new Color(1, 1, 1, Mathf.Cos(time- (Mathf.PI / 2 + wait)));
            SAFE.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Sin(safeTime));
        }
        else if (time - wait >= Mathf.PI)
        {
            safeTime += Time.deltaTime * speed;
            if (safeTime < Mathf.PI)
            {
                SAFE.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Sin(safeTime));
            }
            else
            {
                SAFE.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }
            spriteRenderer.color = new Color(1, 1, 1, 0);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, Mathf.Sin(time));
        }
    }

    void GenerateChip()
    {
        GameObject.Instantiate(chip, transform.position, Quaternion.identity);
    }

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1,1,1,0);
        SAFE.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        time = 0;
        safeTime = 0;
        Invoke("GenerateChip", Mathf.PI / 2 + 1.5f);
    }
}
