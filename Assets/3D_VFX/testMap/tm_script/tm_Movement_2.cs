using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tm_Movement_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed; // default = 70
    Rigidbody rrigidbody;
    float gravity = -9.8f;
    float glidingGravityScale = 0.01f;
    Vector3 GlideVec;
    public float GlideTurnValue = 0;
    float GlideSpeed = 2;
    Animator animator;
    public float TurnValue;
    void Start()
    {
        rrigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Turn", TurnValue);
    }

    // Update is called once per frame
    void Update()
    {
        moveforward();
        moveright();
    }

    void moveforward()
    {
        rrigidbody.velocity = new Vector3(0, gravity * glidingGravityScale, 0);
        rrigidbody.AddForce(transform.forward * 100f, ForceMode.Force);
    }
    void moveright()
    {
        GlideVec = new Vector3(transform.right.x, 0, transform.right.z).normalized;
        Vector3 TempVec = GlideVec * GlideTurnValue;
        transform.Translate(TempVec * GlideSpeed * Time.deltaTime, Space.World);
    }
}
