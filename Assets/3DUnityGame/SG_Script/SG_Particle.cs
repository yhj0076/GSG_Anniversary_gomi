using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_Particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyself());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyself()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Destroy(this.gameObject);
    }
    
}
