using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_DangerZone_WTF : MonoBehaviour
{
    new Renderer renderer;

    float changetime = 0;
    float time = 0;
    public float speed;
    private void OnEnable()
    {
        changetime = 0;
        time = 0;
        renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b,0);
    }

    // Update is called once per frame
    void Update()
    {
        changetime += Time.deltaTime*speed;
        time += Time.deltaTime;
        //renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, Mathf.Sin(changetime)/2);
        if(time < transform.parent.GetComponent<SA_WTF>().delayTime)
        {
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, Mathf.Sin(changetime) / 2);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
