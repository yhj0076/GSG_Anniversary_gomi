using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;

public class tm_Glide : MonoBehaviour
{
    public Rigidbody rrigidbody;
    public bool BglidingControl;
    public Animator animator;
    public GameObject Glide;
    public Transform GlidePlace;
    float glidingGravityScale = 0.01f;
    float gravity = -9.8f;
    //  public GameObject CinemaCam;
    public CinemachineVirtualCamera virtualcam;
    CinemachineComponentBase cinemaschineeBase;
    float GlideSpeed = 2;
    Vector3 GlideVec;
    float GlideTurnValue;
    //bool Bmoving;
    float GlideAnimTurnValue;
    float GlideValue = 1.25f;
    float changeSpeed = 4f;
    public RigBuilder rigbuilder;
    public GameObject[] GlideObjects;
    public Vector3[] GlideObjectRots;
    public float[] GlideDistance;
    public bool bGliding;

    private void Start()
    {
        ParaGlidingGame_Init();
    }
    void Update()
    {
        //ClickBtnParaGlide();
        InputGliding();
    }
    private void FixedUpdate()
    {
        DoParaGlide();
    }
    public void ParaGlidingGame_Init()
    {
        GlideOn();
    }

    void DoParaGlide()
    {
        if (animator.GetBool("Gliding") && !bGliding)
        {

            rrigidbody.velocity = new Vector3(0, gravity * glidingGravityScale, 0);
            rrigidbody.AddForce(transform.forward * 100f, ForceMode.Force);

        }
    }
    void InputGliding()
    {
        if (BglidingControl)
        {
            GlideTurnValue = Input.GetAxisRaw("Horizontal");
            //GlideTurnValue = Input.GetAxisRaw("Horizontal");
            if (GlideTurnValue != 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    GlideAnimTurnValue += -GlideValue * Time.deltaTime;
                    GlideAnimTurnValue = Mathf.Clamp(GlideAnimTurnValue, -1, 1);
                    if (GlideTurnValue == -1)
                        SG_GliderFace.gliderface.ChangeFace(0, 5);

                }

                else if (Input.GetKey(KeyCode.D))
                {
                    GlideAnimTurnValue += +GlideValue * Time.deltaTime;
                    GlideAnimTurnValue = Mathf.Clamp(GlideAnimTurnValue, -1, 1);
                    if (GlideTurnValue == 1)
                        SG_GliderFace.gliderface.ChangeFace(1, 6);

                }

            }
            else
            {

                SG_GliderFace.gliderface.ReturnFace(0, 5);
                SG_GliderFace.gliderface.ReturnFace(1, 6);
                if (GlideAnimTurnValue < 0)
                {
                    GlideAnimTurnValue += +GlideValue * Time.deltaTime;
                    GlideAnimTurnValue = Mathf.Clamp(GlideAnimTurnValue, -1, 0);

                }
                else if (GlideAnimTurnValue > 0)
                {
                    GlideAnimTurnValue += -GlideValue * Time.deltaTime;
                    GlideAnimTurnValue = Mathf.Clamp(GlideAnimTurnValue, 0, 1);

                }
            }

            animator.SetFloat("Turn", GlideAnimTurnValue);
            //   Debug.Log(GlideTurnValue);
            GlideVec = new Vector3(transform.right.x, 0, transform.right.z).normalized;
            Vector3 TempVec = GlideVec * GlideTurnValue;
            transform.Translate(TempVec * GlideSpeed * Time.deltaTime, Space.World);
            //
        }
    }

    public void GlideOnControl()
    {
        BglidingControl = true;
        StartCoroutine(GlideForwardValue());
    }
    IEnumerator GlideForwardValue()
    {
        float tempf = 0;
        animator.SetFloat("Forward", 0);
        while (true)
        {
            tempf += Time.deltaTime * changeSpeed;
            tempf = Mathf.Clamp(tempf, 0, 1);
            animator.SetFloat("Forward", tempf);
            if (tempf >= 1)
                break;
            yield return null;
        }
    }
    public void GlideOn()
    {
        bGliding = false;
        animator.Play("GlideOn");
        animator.SetBool("Gliding", true);
        rrigidbody.useGravity = false;
        rigbuilder.enabled = true;
        Glide.SetActive(true);
        //Glide.transform.parent = GlidePlace;
        cinemaschineeBase = virtualcam.GetCinemachineComponent(CinemachineCore.Stage.Body);
        (cinemaschineeBase as CinemachineTransposer).m_FollowOffset.z = -3f;
    }
}
