using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_Dissolve : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer rrenderer;
    float DissolveSpeed = 0.5f;
    Coroutine coroutine;
    void Start()
    {
        rrenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDissolve()
    {
        coroutine = StartCoroutine(Dissolve());
    }
    public void EndDissolve()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator Dissolve()
    {
        float CurrentValue = -1;
        while(true)
        {
          //  CurrentValue = Random.Range(-1, -0.91f);
            CurrentValue += Time.unscaledDeltaTime * DissolveSpeed;
           // CurrentValue = Mathf.Clamp(CurrentValue, -1f, -0.6f);
            rrenderer.material.SetFloat("_Dissolve_int", CurrentValue);
            /* if (DissolveSpeed > 0 && CurrentValue >= -0.6f)
             {
                 DissolveSpeed = -DissolveSpeed;
             }
             else if(DissolveSpeed < 0 && CurrentValue <= -1f)
             {
                 DissolveSpeed = -DissolveSpeed;
             }*/
            if (CurrentValue >= 1)
                break;
          //  Debug.Log(rrenderer.material.GetFloat("_Dissolve_int"));
            yield return null;
        }
        
        
    }
}
