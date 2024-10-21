using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kino;
public class SG_LifeSystem : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public Image[] Hearts;
    public Sprite Heart;
    public Sprite Transparent;
    float WaitTimeForNextHeart = 0.4f;
    public int HeartTotalNum = 3; //최대 : 9
    float DeathglitchSpeed = 1f;
    public int CurrentHeartNum;
    //float CameraLength = 1.5f;
    Animator animator;
    public GameObject MainCamera;
    public GameObject CMCam;
    public static SG_LifeSystem lifeSystem;
    private void Awake()
    {
        lifeSystem = this;
    }
    void Start()
    {
      //  SetUpLife();
        player = GameObject.Find("gosegu");
        animator = GameObject.Find("gosegu").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetUpLife()
    {
        StartCoroutine(SetUP_Image());
    }
    IEnumerator SetUP_Image()
    {
        CurrentHeartNum = HeartTotalNum - 1;
        for(int i = 0; i < 9; i++)
        {
            Hearts[i].sprite = Transparent;
            yield return null;
        }
        for (int i = 0; i <= CurrentHeartNum; i++)
        {
            Hearts[i].sprite = Heart;
            yield return new WaitForSeconds(WaitTimeForNextHeart);
        }
    }

    IEnumerator SetUpRunningDeath()
    {
        SG_RunningGame.runninggame.stopRunning();
        animator.Play("RunningDeath"); 
        while(true)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.DownDeath"))
            {
                break;
            }
            yield return null;
        }
        float currentValue = 0;
        SG_PlaySFX.sgplaySFX.playSFX(6);
        while (currentValue < 1)
        {
            currentValue += Time.deltaTime * DeathglitchSpeed;
            MainCamera.GetComponent<AnalogGlitch>().scanLineJitter = currentValue;
            MainCamera.GetComponent<AnalogGlitch>().verticalJump = currentValue;
            MainCamera.GetComponent<AnalogGlitch>().colorDrift = currentValue;
            yield return null;
        }
        SG_Camera.sgcamera.FadingOut();
        MainCamera.GetComponent<AnalogGlitch>().scanLineJitter = 0;
        MainCamera.GetComponent<AnalogGlitch>().verticalJump = 0;
        MainCamera.GetComponent<AnalogGlitch>().colorDrift = 0;
        SG_GameManager.gameManager.Death_Load();
        SG_Camera.sgcamera.SetUpCameraRootRotation();
        //  MainCamera.transform.position = new Vector3(SG_GameManager.SavePoint.x, SG_GameManager.SavePoint.y, SG_GameManager.SavePoint.z + CameraLength);
        yield return new WaitForSeconds(0.3f);
        if (HeartTotalNum < 9)
            HeartTotalNum++;
        SetUpLife();
        animator.Play("Revive");
        yield return new WaitForSeconds(2.01f);
        SG_RunningGame.runninggame.startRunning();
        yield return null;
    }
    public void GlidingDeath()
    {
        StartCoroutine(SetUpGlidingDeath());
    }

    IEnumerator SetUpGlidingDeath()
    {
        SG_ParaGliding.paraGliding.GlideOff();
        animator.Play("GlidingDeath");

        yield return new WaitForSeconds(0.8f);

        SG_Camera.sgcamera.FadingOut();
        SG_ParaGliding.paraGliding.GlideOn();
        SG_GameManager.gameManager.Death_Load();
        //  MainCamera.transform.position = new Vector3(SG_GameManager.SavePoint.x, SG_GameManager.SavePoint.y, SG_GameManager.SavePoint.z + CameraLength);
        yield return new WaitForSeconds(0.3f);
        
        if (HeartTotalNum < 9)
            HeartTotalNum++;
        SetUpLife();

        yield return null;
    }
    public void RunningDeath()
    {
        StartCoroutine(SetUpRunningDeath());
    }

    public void Hit_Glitch()
    {
        StartCoroutine(SetUp_HitGlitch());
    }
    IEnumerator SetUp_HitGlitch()
    {
        float currentValue = 0;
        SG_PlaySFX.sgplaySFX.playSFX(6);
        while (currentValue < 0.7f)
        {
            currentValue += Time.deltaTime * 1.25f;
            MainCamera.GetComponent<AnalogGlitch>().scanLineJitter = currentValue;
            MainCamera.GetComponent<AnalogGlitch>().colorDrift = currentValue;
            yield return null;
        }
        MainCamera.GetComponent<AnalogGlitch>().scanLineJitter = 0;
        MainCamera.GetComponent<AnalogGlitch>().colorDrift = 0;
    }


}
