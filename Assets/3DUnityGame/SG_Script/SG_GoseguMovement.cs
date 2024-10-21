using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_GoseguMovement : MonoBehaviour
{
   // [SerializeField]
    public SG_ParkourTrigger TriggerColidBox;

    public static SG_GoseguMovement gosegumovement;
    // Start is called before the first frame update
    private void Awake()
    {
        gosegumovement = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveToGrapleBox()
    {

        TriggerColidBox.isGraple = true;

        //transform.position = Vector3.MoveTowards(transform.position, HitChildObject.position, 200 * Time.deltaTime);

    }
    public void Slide()
    {
        TriggerColidBox.BSliding = true;
    }
    public void Vault()
    {
        TriggerColidBox.BVaulting = true;
    }
    public void Dodge()
    {
        TriggerColidBox.BDodging = true;
    }
    public void TimeScaleLow()
    {
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    public void TimeScaleOrigin()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    public void TimeScaleCutScene()
    {
        Time.timeScale = 0.05f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}
