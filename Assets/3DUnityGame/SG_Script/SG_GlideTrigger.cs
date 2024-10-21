using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_GlideTrigger : MonoBehaviour
{
    public int AirMode; // 0 : Forward, 1 : Up
    Rigidbody Hitrigidbody;
    Transform Hittransform;
    Animator Hitanimator;
    float ForwardPower = 8f;
    float UpPower = 5;
    float ForwardSpeed = 900f;
    float UpSpeed = 120f;
    public Transform Portal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gosegu")
        {

            SG_ParaGliding.paraGliding.bGliding = true;
            SG_ParaGliding.paraGliding.BglidingControl = false;
            Hitrigidbody = other.GetComponent<Rigidbody>();
            Hittransform = other.transform;
            Hitanimator = other.GetComponent<Animator>();

            
            switch (AirMode)
            {
                case 0:
                    // gameObject.GetComponent<Rigidbody>().AddForce(Hittransform.forward * ForwardPower, ForceMode.Force);

                    // OriginVelocity = Hitrigidbody.velocity;
                    Vector3 TempDir = Portal.position - Hittransform.position;
                    SG_PlaySFX.sgplaySFX.playSFX(8);
                    StartCoroutine(PlayerMoveTo(Hittransform.position + TempDir * ForwardPower, ForwardSpeed * Time.deltaTime));
                    Hitanimator.SetTrigger("Glide_Forward");
                    SG_ParticleManager.particleManager.DashVFXOn();
                    break;
                case 1:
                    StartCoroutine(PlayerMoveTo(Hittransform.position + Hittransform.up * UpPower, UpSpeed * Time.deltaTime));
                    Hitanimator.Play("Pushed_Up");
                    break;
                case 2:
                    SG_PlaySFX.sgplaySFX.playSFX(8);
                    StartCoroutine(PlayerMoveTo(Hittransform.position + Hittransform.forward * 7f, 500 * Time.deltaTime));
                    Hitanimator.SetTrigger("Glide_Forward");
                    SG_ParticleManager.particleManager.DashVFXOn();
                    break;
                default:
                    break;
            }

        }
    }
    IEnumerator PlayerMoveTo(Vector3 dirpos, float speed)
    {
        Vector3 DirPos = dirpos;
        float Speed = speed;
        while (true)
        {
            Hittransform.position = Vector3.MoveTowards(Hittransform.position,
              DirPos, Time.deltaTime * Speed);
            if (Vector3.Distance(Hittransform.position, DirPos) <= 0.5f)
            {
              //  Debug.Log("Reached");
                SG_ParaGliding.paraGliding.bGliding = false;
                SG_ParaGliding.paraGliding.BglidingControl = true;
                SG_ParticleManager.particleManager.DashVFXOff();
                break; 
            }
            yield return null;
        }
    }
}
