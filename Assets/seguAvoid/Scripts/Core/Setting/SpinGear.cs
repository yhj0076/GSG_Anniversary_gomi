using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SpinGear : MonoBehaviour
{
    float time = 0;
    public float speed;
    private void Start()
    {
        time = 0;      
    }
    private void OnMouseOver()
    {
        time += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time * speed);
    }
}
