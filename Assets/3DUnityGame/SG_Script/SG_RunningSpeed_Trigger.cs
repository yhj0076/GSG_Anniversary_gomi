using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_RunningSpeed_Trigger : MonoBehaviour
{
    public bool Triggered = false;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gosegu")
        {
            if(!Triggered)
            {
                SG_PlaySFX.sgplaySFX.playSFX(8);
                SG_RunningGame.runninggame.speed = 20f;
                SG_ParticleManager.particleManager.DashVFXOn();
            }
            else
            {
                SG_RunningGame.runninggame.speed = 11.5f;
                SG_ParticleManager.particleManager.DashVFXOff();
            }
        }    
    }
}
