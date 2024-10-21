using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SG_ParkourTrigger : MonoBehaviour
{
    bool CanInput = false;
    bool BColied;
    public int DirValue;
    public GameObject player;
    //string PlayAnimName;
   // [SerializeField] Transform PlayerCamera;
    [SerializeField] Transform CameraRoot;
    //  float SphereM = 0.3f;
    // float Distance = 20f;
    //public LayerMask hitmask;
    int GrapleNum;
   // bool CanGraple;
    //bool BGrapling;
    float GrapleSpeed;
    public Animator animator;
   // RaycastHit hit;
    Transform HitChildObject;
    public bool isGraple;
    bool isCameraMoving;
    public Transform[] GrapleBoxes; 
    //bool BTurningCamera;
    float timeslowvalue = 0.1f;
    float origintimevalue = 1.0f;
    public bool BSliding;
    public bool BDodging;
    bool BSlideTurningCamera;
    bool BDodgeTurningCamera;
   // bool turnedSlideCamera;
  // bool turnedDodgeCamera;
    float SlideValue = 6f;
  //  bool SG_CanSlide;
    //bool SG_CanDodge;
    //bool SG_CanVault;
    public bool BVaulting;
    Vector3 SlideEnd;
    Vector3 VaultEnd;
    Vector3 DodgeEnd;
    public float DodgeValue = 3f;
    float DodgeSpeed = 8f;
    Vector3 DodgeV;
    int DodgeDirectionNum;
    float VaultValue = 5f;
    bool BVaultTurningCamera;
   // bool turnedVaultCamera;
    public bool Colied;
    public int PatternType;
  //  bool seguncolided;
    
    [System.Serializable]
    public struct PattrnList
    {
        public int[] patternList;
    }
    public PattrnList[] PL = new PattrnList[0];
  
    
    
    
    int CurrentPattern;
    int tempkey;
    bool pushed;
    float SpaceBarValue;
    float speedSlider = 0.7f;
    public float TimeOutSpeed = 1.0f;
    public Coroutine timeout_coroutine;
    public Coroutine Parkour_coroutine;
    bool HardModeSUCCESS;
    int gameMode;
    public GameObject SeguHairClip;
    GameObject HairClip;
    float HairClipPos = 25;
    public Transform Obstacle;
    public static SG_ParkourTrigger parkourtrigger;
    private void Awake()
    {
        parkourtrigger = this;
    }
    private void Start()
    {
      //  PlayerCamera = SG_Camera.sgcamera.PlayerCamera;
        CameraRoot = SG_Camera.sgcamera.CameraRoot;
        player = GameObject.Find("gosegu");
        animator = player.GetComponent<Animator>();
    }
    
    private void Update()
    {
        InputPatternKey();
        if (BColied)
        {
            CheckArrived();
            CheckSlided();
            CheckVaulted();
            CheckDodged();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Colied && other.gameObject.name == "gosegu")
        {
            // player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            SG_UIController.UIcont.isESC = true;
            Colied = true;
            BColied = true;
            CanInput = true;
            gameMode = SG_GameManager.gameManager.GameMode;
            if (DirValue < 5)
            {
                if (gameMode == 0)
                {

                    SG_RunningGame.runninggame.stopRunning();
                    Time.timeScale = timeslowvalue;
                    Time.fixedDeltaTime = Time.timeScale * 0.02f;
                    SetUpCommand();

                }
                else SetUpCommand();
                
            }
            SG_GoseguMovement.gosegumovement.TriggerColidBox = this;
            // SG_Camera.sgcamera.canmovecamera = false;
            //     this.gameObject.GetComponent<BoxCollider>().enabled = false;
            switch (DirValue)
            {
                case 1:
                    BVaultTurningCamera = true;
                    break;
                case 2:
                    BSlideTurningCamera = true;
                    break;
                case 3:
                    isCameraMoving = true;
                    break;
                case 4:
                    BDodgeTurningCamera = true;
                    
                    if (gameMode == 1)
                    {
                        //  arrowImages[0].sprite = SG_UIController.UIcont.Arrows[DodgeDirectionNum];                       
                        //DodgeDirectionNum = Random.Range(3, 5);
                        //DodgeV = DodgeDirectionNum == 3 ? player.transform.right : -player.transform.right;
                        DodgeV = PL[0].patternList[0] == 3 ? player.transform.right : -player.transform.right;
                        //PL[0].patternList[0] = DodgeDirectionNum;
                        Vector3 tempPos = player.transform.position + player.transform.forward * HairClipPos - player.transform.right * 12f;
                        HairClip = Instantiate(SeguHairClip, new Vector3(tempPos.x, tempPos.y + 2, tempPos.z), Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y + 185, player.transform.rotation.z));
                        Obstacle = HairClip.transform;
                        GrapleBoxes[0] = HairClip.transform;
                    }
                    else
                    {
                        DodgeV = PL[0].patternList[0] == 3 ? player.transform.right : -player.transform.right;
                    }
                    break;
                case 5:
                    animator.SetBool("Falling", true);
                    Colied = false;
                    BColied = false;
                    CanInput = false;
                    break;
                case 6:
                    SG_RunningGame.runninggame.stopRunning();
                    player.GetComponent<Rigidbody>().useGravity = false;
                    Vector3 tempPlayerRot = GrapleBoxes[GrapleNum].position - player.transform.position;
                    tempPlayerRot.y = 0;
                    player.transform.rotation = Quaternion.LookRotation(tempPlayerRot);
                    HitChildObject = GrapleBoxes[GrapleNum].GetChild(0);
                    GrapleSpeed = (Vector3.Distance(player.transform.position, GrapleBoxes[GrapleNum].position) - 1);
                    if (HitChildObject.position.y - player.transform.position.y >= 3)
                    {
                        GrapleSpeed += HitChildObject.position.y - player.transform.position.y - 1;

                    }
                    animator.Play("Flip");
                    break;
                default:
                    break;

            }

            
        }
       /* else if(!seguncolided && (other.gameObject.name == "segun"))
        {
            seguncolided = true;
            switch (DirValue)
            {
                case 1:
                    SG_SegunMovement.segunMovement.Segun_GrappleBoxes = GrapleBoxes;
                    SG_SegunMovement.segunMovement.SegunParkourMovement(1, transform);
                    break;
                case 2:
                    SG_SegunMovement.segunMovement.Segun_GrappleBoxes = GrapleBoxes;
                    SG_SegunMovement.segunMovement.SegunParkourMovement(2, transform); 
                    break;
                case 3:
                    SG_SegunMovement.segunMovement.Segun_GrappleBoxes = GrapleBoxes;
                    SG_SegunMovement.segunMovement.SegunParkourMovement(3, GrapleBoxes[0]);
                    break;
                default:
                    break;
            }


        }*/
    }
    void InputPatternKey()
    {
        if(CanInput)
        {
            if(PatternType == 1) // 방향키
            {
                if(CurrentPattern < PL[GrapleNum].patternList.Length)
                {
                    if(Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        tempkey = 1;
                        pushed = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        tempkey = 2;
                        pushed = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        tempkey = 3;
                        pushed = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        tempkey = 4;
                        pushed = true;
                    }
                    if(pushed)
                    {
                        pushed = false;
                        if (tempkey == PL[GrapleNum].patternList[CurrentPattern])
                        {
                            SG_UIController.UIcont.arrowImages[CurrentPattern].enabled = false;
                            SG_ParticleManager.particleManager.SpawnHitParticle(0, SG_UIController.UIcont.arrowImages[CurrentPattern]);
                            SG_PlaySFX.sgplaySFX.playSFX(0);
                            CurrentPattern += 1;
                           // Debug.Log("Pattern Correct!");
                        }
                        else
                        {
                            for (int i = 0; i < CurrentPattern; i++)
                            {
                                SG_ParticleManager.particleManager.SpawnHitParticle(1, SG_UIController.UIcont.arrowImages[i]);
                                SG_UIController.UIcont.arrowImages[i].enabled = true;
                            }
                            SG_PlaySFX.sgplaySFX.playSFX(2);
                            //  Debug.Log("Pattern Not Correct! Reset");
                            CurrentPattern = 0;
                        }
                    }
                }
                else
                {
                    SG_UIController.UIcont.trigger_canvasgroup.alpha = 0;
                    CanInput = false;
                    for (int i = 0; i < PL[GrapleNum].patternList.Length; i++)
                    {
                        SG_UIController.UIcont.arrowImages[i].enabled = true;
                        SG_UIController.UIcont.arrowImages[i].sprite = SG_LifeSystem.lifeSystem.Transparent;
                       // SG_UIController.UIcont.arrowImages[i].material = null;
                    }
                    CurrentPattern = 0;
                    
                    if (gameMode == 0)
                    {
                        if (timeout_coroutine != null)
                        {
                            StopCoroutine(timeout_coroutine);
                            SG_UIController.UIcont.TimeSlider.value = 0;
                            SG_UIController.UIcont.TimeSlider.GetComponent<CanvasGroup>().alpha = 0;
                            timeout_coroutine = null;
                        }
                        ChangeDir();
                    }
                    else HardModeSUCCESS = true;

                    SG_PlaySFX.sgplaySFX.playSFX(1);
                    //Colied = false;
                }
            }
            else // 스페이스바
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Slider SpacebarSlider = SG_UIController.UIcont.SpacebarSlider;
                    if (SpaceBarValue - 0.08f<= SpacebarSlider.value && SpacebarSlider.value <= SpaceBarValue + 0.08f)
                    {
                        CanInput = false;
                        SG_ParticleManager.particleManager.SpawnHitParticle(0, SG_UIController.UIcont.currentPos);
                        SG_PlaySFX.sgplaySFX.playSFX(0);
                        
                        //Debug.Log(SpaceBarValue + " / " + SpacebarSlider.value);
                        if (Parkour_coroutine != null)
                        {
                            StopCoroutine(Parkour_coroutine);
                            Parkour_coroutine = null;
                        }

                        SG_UIController.UIcont.trigger_canvasgroup.alpha = 0;
                        //Colied = false;
                        if (gameMode == 0)
                        {
                            if (timeout_coroutine != null)
                            {
                                StopCoroutine(timeout_coroutine);
                                SG_UIController.UIcont.TimeSlider.value = 0;
                                SG_UIController.UIcont.TimeSlider.GetComponent<CanvasGroup>().alpha = 0;
                                timeout_coroutine = null;
                            }
                            ChangeDir();
                        }
                        else HardModeSUCCESS = true;

                        SG_PlaySFX.sgplaySFX.playSFX(1);
                    }
                    else
                    {
                        //Debug.Log(SpaceBarValue + " / " + SpacebarSlider.value);
                       // Debug.Log("Slider Value Pos Not Correct!");
                    }
                }
            }
        }
    }
    IEnumerator MovementSlider()
    {
        bool reached = false;
        Slider SpacebarSlider = SG_UIController.UIcont.SpacebarSlider;
        while (true)
        {
            if (SpacebarSlider.value < 1 && !reached)
            {
                SpacebarSlider.value += Time.unscaledDeltaTime * speedSlider;
            }
            else if (SpacebarSlider.value >= 1)
                reached = true;
            if (reached && SpacebarSlider.value > 0)
            {
                SpacebarSlider.value -= Time.unscaledDeltaTime * speedSlider;
            }
            else if (SpacebarSlider.value <= 0)
                reached = false;
            yield return null;
        }
        
       // yield return null;
    }
    void ChangeDir()
    {
        Time.timeScale = origintimevalue;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        switch (DirValue)
        {
            case 1:
                
                   // SG_CanVault = true;
                player.GetComponent<Rigidbody>().useGravity = false;
                player.GetComponent<CapsuleCollider>().enabled = false;
                VaultEnd = player.transform.position + player.transform.forward * VaultValue;
                animator.Play("Vaulting");
                Debug.Log("Vaulting");
                        
                
                break;
            case 2:
                
                   // SG_CanSlide = true;
                player.GetComponent<Rigidbody>().useGravity = false;
                player.GetComponent<CapsuleCollider>().enabled = false;
                SlideEnd = player.transform.position + player.transform.forward * SlideValue;
                animator.Play("Slide");
                Debug.Log("Sliding");
                
                break;
            case 3:
               // RaycastHit[] Hits = Physics.SphereCastAll(PlayerCamera.position, SphereM, PlayerCamera.forward, Distance, hitmask);

             //   CanGraple = true;
                
                    //BGrapling = true;
                    
                player.GetComponent<Rigidbody>().useGravity = false;
                Vector3 tempPlayerRot = GrapleBoxes[GrapleNum].position - player.transform.position;
                tempPlayerRot.y = 0;
                player.transform.rotation = Quaternion.LookRotation(tempPlayerRot);
                HitChildObject = GrapleBoxes[GrapleNum].GetChild(0);
                GrapleSpeed = (Vector3.Distance(player.transform.position, GrapleBoxes[GrapleNum].position) - 1);
                if (HitChildObject.position.y - player.transform.position.y >= 3)
                {
                    GrapleSpeed += HitChildObject.position.y - player.transform.position.y - 1;
                        
                }
                animator.Play("Flip");
                
                break;
            case 4:
                
                   // SG_CanDodge = true;
                player.GetComponent<Rigidbody>().useGravity = false;
                player.GetComponent<CapsuleCollider>().enabled = false;
                if(gameMode == 1)    
                    DodgeEnd = player.transform.position + DodgeV * DodgeValue;
                else
                {
                    DodgeEnd = SeguHairClip.transform.position;
                }
                if (PL[0].patternList[0] == 3)
                    animator.Play("Dodge_Right");
                else animator.Play("Dodge_Left");
                Debug.Log("Dodging");
                
                break;
            default:
                break;
        }
        
        
    }

    void CheckArrived()
    {
        if (isGraple)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, HitChildObject.position, GrapleSpeed * Time.fixedDeltaTime);
            if (Vector3.Distance(player.transform.position, HitChildObject.position) <= 0.2f)
            {
                isGraple = false;
                player.GetComponent<Rigidbody>().useGravity = true;
                //player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                Colied = false;
                SG_UIController.UIcont.isESC = false;
                // SG_RunningGame.runninggame.SpawnJumpParticle();
                GrapleNum++;

                isCameraMoving = true;
                
                
                
            }

        }
        if (isCameraMoving)
        { 
            if (GrapleBoxes.Length - 1 >= GrapleNum)
            {
                isCameraMoving = false;
                StartCoroutine(StartTurnCamera());
                UISetUp();

            }

            else
            { 
                if (!(animator.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Flip")))
                {
                    GrapleNum = 0;
                    BColied = false;
                    isCameraMoving = false;
                    SG_RunningGame.runninggame.SetUpClip();
                    StartCoroutine(RotationCamera());
                  //  SG_Camera.sgcamera.canmovecamera = true;
                }
            } 
        }
    }
    void CheckSlided()
    {
        if (BSliding)
        {
            
            player.transform.position = Vector3.MoveTowards(player.transform.position, SlideEnd, SlideValue * Time.fixedDeltaTime);
            if (Vector3.Distance(player.transform.position, SlideEnd) <= 0.2f)
            {
                Debug.Log("Slide Arrived");
                GrapleNum++;
                Colied = false;
                BColied = false;
                SG_UIController.UIcont.isESC = false;
                player.GetComponent<Rigidbody>().useGravity = true;
                player.GetComponent<CapsuleCollider>().enabled = true;
                BSliding = false;
                BSlideTurningCamera = true;

            }

        }
        if (BSlideTurningCamera)
        {
            if (GrapleBoxes.Length - 1 >= GrapleNum)
            {
                BSlideTurningCamera = false;
               // SG_CanSlide = false;
                StartCoroutine(RotationCamera());
                UISetUp();
                SG_RunningGame.runninggame.RunningParticle.Play();
            }
            else
            {
                GrapleNum = 0;
                BSlideTurningCamera = false;
               
                SG_RunningGame.runninggame.SetUpClip();
                StartCoroutine(RotationCamera());

            }
        }
    }
    void CheckDodged()
    {
        if (BDodging)
        {
            
            player.transform.position = Vector3.MoveTowards(player.transform.position, DodgeEnd, DodgeSpeed * Time.fixedDeltaTime);
            if (Vector3.Distance(player.transform.position, DodgeEnd) <= 0.2f)
            {
                Debug.Log("Dodged Arrived");
                GrapleNum++;
                Colied = false;
                BColied = false;
                SG_UIController.UIcont.isESC = false;
                player.GetComponent<Rigidbody>().useGravity = true;
                player.GetComponent<CapsuleCollider>().enabled = true;
                BDodging = false;
                BDodgeTurningCamera = true;

            }

        }

        if (BDodgeTurningCamera)
        {
            if (GrapleBoxes.Length - 1 >= GrapleNum)
            {
                /* Vector3 TempRot = player.transform.forward;

                 Quaternion RotateTo = Quaternion.LookRotation(TempRot);

                 CameraRoot.rotation = Quaternion.Lerp(CameraRoot.rotation, RotateTo, 20 * Time.unscaledDeltaTime);
                 if (!turnedVaultCamera)
                 {
                     turnedVaultCamera = true;
                     StartCoroutine(TurnVaultCamera());
                 }*/
                BDodgeTurningCamera = false;
                StartCoroutine(RotationCamera());
                UISetUp();
            }
            else
            {
                GrapleNum = 0;
                BDodgeTurningCamera = false;
                SG_RunningGame.runninggame.SetUpClip();
                //SG_Camera.sgcamera.canmovecamera = true;
                StartCoroutine(RotationCamera());
            }
        }
    }
    /*IEnumerator TurnDodgeCamera()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        BDodgeTurningCamera = false;
        turnedDodgeCamera = false;
        SG_CanDodge = false;
        
        timeout_coroutine = StartCoroutine(CheckDistance());
    }*/
    void CheckVaulted()
    {
        if (BVaulting)
        {
            
            player.transform.position = Vector3.MoveTowards(player.transform.position, VaultEnd, VaultValue * Time.fixedDeltaTime);
            if (Vector3.Distance(player.transform.position, VaultEnd) <= 0.2f)
            {
                Debug.Log("Vault Arrived");
                GrapleNum++;
                Colied = false;
                BColied = false;
                SG_UIController.UIcont.isESC = false;
                SG_RunningGame.runninggame.SpawnJumpParticle();
                player.GetComponent<Rigidbody>().useGravity = true;
                player.GetComponent<CapsuleCollider>().enabled = true;
                BVaulting = false;
                BVaultTurningCamera = true;

            }

        }
        if (BVaultTurningCamera)
        {
            if (GrapleBoxes.Length - 1 >= GrapleNum)
            {
                /* Vector3 TempRot = player.transform.forward;

                 Quaternion RotateTo = Quaternion.LookRotation(TempRot);

                 CameraRoot.rotation = Quaternion.Lerp(CameraRoot.rotation, RotateTo, 20 * Time.unscaledDeltaTime);
                 if (!turnedVaultCamera)
                 {
                     turnedVaultCamera = true;
                     StartCoroutine(TurnVaultCamera());
                 }*/
                BVaultTurningCamera = false;
                StartCoroutine(RotationCamera());
                UISetUp();
            }
            else
            {
                GrapleNum = 0;
                BVaultTurningCamera = false;
                SG_RunningGame.runninggame.SetUpClip();
                //SG_Camera.sgcamera.canmovecamera = true;
                StartCoroutine(RotationCamera());
            }
        }
    }
    IEnumerator RotationCamera()
    {
        Vector3 TempRot = new Vector3(15, 90f, 0f);
        //TempRot.y = 0;
        Quaternion RotateTo = Quaternion.Euler(TempRot);
        float starttime = Time.realtimeSinceStartup;
        while (true)
        {
            CameraRoot.rotation = Quaternion.Slerp(CameraRoot.rotation, RotateTo, 20 * Time.unscaledDeltaTime);

            if (Time.realtimeSinceStartup - starttime >= 1.0f)
            {
                Debug.Log("Rotation Changed");
                break; 
            }

            yield return null;
        }
        
    }
    /*IEnumerator TurnSlideCamera()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        BSlideTurningCamera = false;
        turnedSlideCamera = false;
        //  SG_CanSlide = false;

        UISetUp()
        /////


    }*/
    void UISetUp()
    {
        if (GrapleNum != 0)
        {
          //  SetUpCommand();
          //  SG_UIController.UIcont.trigger_canvasgroup.alpha = 1;
            Colied = true;
            if (gameMode == 0)
            {
                timeout_coroutine = StartCoroutine(ClockTimeOut());
          //      Time.timeScale = timeslowvalue;
               // Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
            else
            {
                timeout_coroutine = StartCoroutine(CheckDistance());
            }
        }
        else
        {
            if (gameMode == 0)
            {
                timeout_coroutine = StartCoroutine(ClockTimeOut());
            }
            else
            {
                timeout_coroutine = StartCoroutine(CheckDistance());
            }
        }
    }
   /* IEnumerator TurnVaultCamera()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        BVaultTurningCamera = false;
        turnedVaultCamera = false;
       // SG_CanVault = false;
        
        
    }*/
    IEnumerator StartTurnCamera()
    {
        Vector3 TempRot = GrapleBoxes[GrapleNum].position - CameraRoot.position;

        Quaternion RotateTo = Quaternion.LookRotation(TempRot);
        float starttime = Time.realtimeSinceStartup;
        while (true)
        {
            CameraRoot.rotation = Quaternion.Lerp(CameraRoot.rotation, RotateTo, 20 * Time.unscaledDeltaTime);
            if (Time.realtimeSinceStartup - starttime >= 1.0f)
            {
                //Debug.Log("Rotation Changed");
                break;
                    
            }
            yield return null;
        }
        
        // yield return new WaitForSecondsRealtime(0.5f);
        //SG_Camera.sgcamera.canmovecamera = true;
        // isCameraMoving = false;
        // BTurningCamera = false;
        //   BGrapling = false;
        //CanGraple = false;

        //   Debug.Log("CameraChanged");
    }
    void SetUpCommand()
    {
        if (PatternType == 1)
        {
            for (int i = 0; i < PL[GrapleNum].patternList.Length; i++)

            {
                SG_UIController.UIcont.arrowImages[i].sprite = SG_UIController.UIcont.Arrows[PL[GrapleNum].patternList[i]];
            }
            SG_UIController.UIcont.TextImage.sprite = SG_UIController.UIcont.Texts[0];
            SG_UIController.UIcont.ArrowsGroup.alpha = 1;
            SG_UIController.UIcont.SliderGroup.alpha = 0;
        }
        else
        {
            SG_UIController.UIcont.TextImage.sprite = SG_UIController.UIcont.Texts[1];
            int ranpos = Random.Range(-250, 250);
            SG_UIController.UIcont.currentPos.rectTransform.anchoredPosition = new Vector3(ranpos, 0, 0);
            SpaceBarValue = (ranpos + 340) * 0.00145f;
            if(SpaceBarValue > 0.5f)
                SG_UIController.UIcont.SpacebarSlider.value = 0;
            else
                SG_UIController.UIcont.SpacebarSlider.value = 1;
            SG_UIController.UIcont.ArrowsGroup.alpha = 0;
            SG_UIController.UIcont.SliderGroup.alpha = 1;
            Parkour_coroutine = StartCoroutine(MovementSlider());
        }
        SG_UIController.UIcont.trigger_canvasgroup.alpha = 1;

    }
    public IEnumerator ClockTimeOut()
    {
        double startTime = 3f;
        float currentTime = 0f;
        Slider TimeOutSlider = SG_UIController.UIcont.TimeSlider;
        TimeOutSlider.GetComponent<CanvasGroup>().alpha = 1;
        while (true)
        {
            currentTime += Time.unscaledDeltaTime * TimeOutSpeed;
            TimeOutSlider.value = currentTime * (float)(1 / startTime);
            if (currentTime >= startTime)
            {
                TimeOutSlider.value = 0;
                TimeOutSlider.GetComponent<CanvasGroup>().alpha = 0;
                Time.timeScale = origintimevalue;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                break;
            }
            yield return null;
        }
        if (Parkour_coroutine != null)
        {
            StopCoroutine(Parkour_coroutine);
            Parkour_coroutine = null;
        }
        else
        {
            CurrentPattern = 0;
            for (int i = 0; i < PL[GrapleNum].patternList.Length; i++)
            { 
                SG_UIController.UIcont.arrowImages[i].enabled = true;
                SG_UIController.UIcont.arrowImages[i].sprite = SG_LifeSystem.lifeSystem.Transparent;
            }
        }
        CanInput = false;
        
      //  SG_GoseguMovement.gosegumovement.TriggerColidBox = null;
        SG_UIController.UIcont.trigger_canvasgroup.alpha = 0;
        SG_RunningGame.runninggame.RunningParticle.Stop();
        int tempnum = SG_LifeSystem.lifeSystem.CurrentHeartNum;
        if (tempnum > 0)
        {
            
            animator.Play(SG_UIController.UIcont.HitAnimations[DirValue]);

            // if (DirValue == 3 && player.transform.position.y - GrapleBoxes[GrapleNum].position.y > 0)
            //    animator.SetBool("Falling", true);
            SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
            //SG_LifeSystem.lifeSystem.Hearts[tempnum].material = null;
            SG_LifeSystem.lifeSystem.CurrentHeartNum = tempnum - 1;
            SG_LifeSystem.lifeSystem.Hit_Glitch();
            //yield return new WaitForSeconds(0.8f);
           // Colied = false;
        }
        else
        {
            //SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
            Colied = false;
            //SG_LifeSystem.lifeSystem.Hearts[tempnum].material = null;
            SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
            SG_LifeSystem.lifeSystem.RunningDeath();
        }
        yield return null;
    }
    public IEnumerator CheckDistance()
    {
        Vector3 startPos = player.transform.position;
        float minustemp = 0;
        float currentTime = 0f;
        float tempDist = 0;
        double startTime = 0;
        float LastDist = 2;
        if (DirValue != 1)
            LastDist = 3;
        Slider TimeOutSlider = SG_UIController.UIcont.TimeSlider;
        TimeOutSlider.GetComponent<CanvasGroup>().alpha = 1;
        while (true)
        {
            minustemp = Obstacle.transform.position.y - startPos.y;
            if (minustemp < 0)
                minustemp = minustemp * -1;
            tempDist = Mathf.Sqrt(Mathf.Pow(Vector3.Distance(startPos, Obstacle.transform.position), 2) - Mathf.Pow(minustemp, 2));
            startTime = tempDist - LastDist;
            currentTime = Vector3.Distance(player.transform.position, startPos);
            TimeOutSlider.value = currentTime * (float)(1 / startTime);
            if ((startTime + LastDist) - currentTime < LastDist)
            {
                TimeOutSlider.GetComponent<CanvasGroup>().alpha = 0;
                TimeOutSlider.value = 0;
                break;
            }
            yield return null;
        }
        if (PatternType == 0)
        {
            if (Parkour_coroutine != null)
            {
                StopCoroutine(Parkour_coroutine);
                Parkour_coroutine = null;
            }
        }
        else
        {
            CurrentPattern = 0;
            for (int i = 0; i < PL[GrapleNum].patternList.Length; i++)
            {
                SG_UIController.UIcont.arrowImages[i].enabled = true;
                SG_UIController.UIcont.arrowImages[i].sprite = SG_LifeSystem.lifeSystem.Transparent;
                //SG_UIController.UIcont.arrowImages[i].material = null;
            }
        }
        CanInput = false;
        Colied = false;
        
        SG_UIController.UIcont.trigger_canvasgroup.alpha = 0;
       
        if (HardModeSUCCESS)
        {
            SG_RunningGame.runninggame.stopRunning();
            HardModeSUCCESS = false;
            ChangeDir();
        }
        else
        { 
            while(true)
            {
                minustemp = Obstacle.transform.position.y - player.transform.position.y;
                if (minustemp < 0)
                    minustemp = minustemp * -1;
                tempDist = Mathf.Sqrt(Mathf.Pow(Vector3.Distance(player.transform.position, Obstacle.transform.position), 2) - Mathf.Pow(minustemp, 2));
                if (tempDist <= 2f)                 
                    break;
               // Debug.Log(tempDist);
                yield return null; 
            }
            SG_GoseguMovement.gosegumovement.TriggerColidBox = null;
            int tempnum = SG_LifeSystem.lifeSystem.CurrentHeartNum;
            if(tempnum > 0)
            {
                animator.Play(SG_UIController.UIcont.HitAnimations[DirValue + 4]);
                if (DirValue == 3 && player.transform.position.y - GrapleBoxes[GrapleNum].position.y > 0)
                    animator.SetBool("Falling", true);
                SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
                //SG_LifeSystem.lifeSystem.Hearts[tempnum].material = null;
                SG_LifeSystem.lifeSystem.CurrentHeartNum = tempnum - 1;
                SG_LifeSystem.lifeSystem.Hit_Glitch();
                
            }
            else
            {
                //SG_LifeSystem.lifeSystem.Hearts[tempnum].material = null;
                SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
                SG_LifeSystem.lifeSystem.RunningDeath();
            }
            
        }
        yield return null;
        /*  yield return new WaitForSeconds(0.5f);
          while (true)
          {
              if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer." + SG_UIController.UIcont.HitAnimations[DirValue + 3]))
              {
                  if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.Recovered__Hard"))
                  {
                      //Debug.Log("!!!");
                      ChangeDir();
                      break;
                  }
              }

              yield return null;
          }
          */

        // Colied = true;

    }
}
