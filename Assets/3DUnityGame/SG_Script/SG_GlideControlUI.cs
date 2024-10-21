using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_GlideControlUI : MonoBehaviour
{
    float FadeSpeed = 0.5f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gosegu")
        {
            StartCoroutine(GlideControlUIFade());
        }
    }

    IEnumerator GlideControlUIFade()
    {
        float currentalpha = 0;
        while(true)
        {
            if (currentalpha >= 1)
                break;
            currentalpha += Time.deltaTime * FadeSpeed;
            SG_UIController.UIcont.GlideControlUI.alpha = currentalpha;
            yield return null;
        }
        while (true)
        {
            if (currentalpha <= 0)
                break;
            currentalpha -= Time.deltaTime * FadeSpeed;
            SG_UIController.UIcont.GlideControlUI.alpha = currentalpha;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
