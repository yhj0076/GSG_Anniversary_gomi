using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;
public class SG_ParaGliding : MonoBehaviour
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
    float GlideSpeed = 2.5f;
    Vector3 GlideVec;
    float GlideTurnValue;
    //bool Bmoving;
    float GlideAnimTurnValue;
    float GlideOffValue = 2f;
    float GlideValue = 1.25f;
    float changeSpeed = 4f;
    public RigBuilder rigbuilder;
    public GameObject[] GlideObjects;
    public Vector3[] GlideObjectRots;
    public float[] GlideDistance;
    public bool bGliding;
    public static SG_ParaGliding paraGliding;

    // Start Pos : "x": 6490,"y": -2,"z": 36.5 // Spped : 130
    private void Awake()
    {
        paraGliding = this;
    }
    //   float GlideTurnValue;
    // Start is called before the first frame update
    void Start()
    {
       // rrigidbody = GetComponent<Rigidbody>();
      //  animator = GetComponent<Animator>();
       // virtualcam = CinemaCam.GetComponent<CinemachineVirtualCamera>();
       
        //rigbuilder = GetComponent<RigBuilder>();
    }

    // Update is called once per frame
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

          //  rrigidbody.velocity = new Vector3(0, 0, 0);
            rrigidbody.AddForce(transform.forward * 200f, ForceMode.Force);
            
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
                    GlideAnimTurnValue += -GlideOffValue * Time.deltaTime;
                    GlideAnimTurnValue = Mathf.Clamp(GlideAnimTurnValue, -1, 1);
                    if (GlideTurnValue == -1)
                        SG_GliderFace.gliderface.ChangeFace(0, 5);

                }

                else if (Input.GetKey(KeyCode.D))
                {
                    GlideAnimTurnValue += +GlideOffValue * Time.deltaTime;
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
                    GlideAnimTurnValue += +GlideOffValue * Time.deltaTime;
                    GlideAnimTurnValue = Mathf.Clamp(GlideAnimTurnValue, -1, 0);

                }
                else if(GlideAnimTurnValue > 0)
                    {
                    GlideAnimTurnValue += -GlideOffValue * Time.deltaTime;
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
        while(true)
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
        animator.Play("GlideOn");
        animator.SetBool("Gliding", true);
        rrigidbody.useGravity = false;
        rrigidbody.velocity = new Vector3(0, 0, 0);
        rigbuilder.enabled = true;
        Glide.SetActive(true);
        bGliding = false;
        //Glide.transform.parent = GlidePlace;
        cinemaschineeBase = virtualcam.GetCinemachineComponent(CinemachineCore.Stage.Body);
        (cinemaschineeBase as CinemachineTransposer).m_FollowOffset.z = -3f;
    }
    public void GlideOff()
    {
        BglidingControl = false;
        Glide.SetActive(false);
        animator.SetBool("Gliding", false);
       // rrigidbody.useGravity = true;
        rigbuilder.enabled = false;
        rrigidbody.velocity = new Vector3(0, 0, 0);
        cinemaschineeBase = virtualcam.GetCinemachineComponent(CinemachineCore.Stage.Body);
        (cinemaschineeBase as CinemachineTransposer).m_FollowOffset.z = -2.8f;
    }
}
