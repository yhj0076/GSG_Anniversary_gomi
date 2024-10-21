using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_ExSpaceBar : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Triggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "gosegu")
        {
            if (!Triggered)
            {
                SG_UIController.UIcont.Push_SpaceBarImage.SetActive(true);
                Triggered = true;
                Debug.Log("Entered");
            }
            else
            {
                SG_UIController.UIcont.Push_SpaceBarImage.SetActive(false);
            }
        }
        
    }
}
