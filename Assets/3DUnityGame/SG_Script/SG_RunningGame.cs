using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_RunningGame : MonoBehaviour
{
    // Start Postion x : 2420, y : -1.35, z : 36.5
    public Animator animator;
    public AnimationClip StretchClip;
    public ParticleSystem RunningParticle;
    public GameObject JumpParticle;
    public Rigidbody playerrigidbody;
    bool isKnocked;
    public static SG_RunningGame runninggame;
    Coroutine coroutine;
    // Start is called before the first frame update
    public Transform[] Dests;
    Transform Destination;
    public float speed = 11.5f; // Default : 11.5 
    public LayerMask floorLayer;
    private void Awake()
    {
        runninggame = this;
    }
    void Start()
    {
       // animator = GetComponent<Animator>();
     //   playerrigidbody = GetComponent<Rigidbody>();
       // RhythmGame_Init();

    }

    public void RhythmGame_Init()
    {
        Destination = Dests[SG_GameManager.gameManager.player.GameMode];
        startRunning();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (animator.GetBool("Falling") && (floorLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            SpawnJumpParticle();
            animator.SetBool("Falling", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
     //  startRunning();
        
        if(isKnocked)
            Recovering();
    }
    private void FixedUpdate()
    {
        CheckRunning();
    }
    public void startRunning()
    {
        StartCoroutine(ERun());
    }
    IEnumerator ERun()
    {
        animator.Play("Stretching");

        float duration = StretchClip.length;
        
        yield return new WaitForSeconds(duration + 0.35f);
      //  animator.Play("Idle To Sprint");
      //  yield return new WaitForSeconds(0.35f);
        animator.SetBool("Running", true);
        RunningParticle.Play();
        yield return null;

    }
    public void startHardMode()
    {
        Destination = Dests[SG_GameManager.gameManager.player.GameMode];
        StartCoroutine(EHardMode());
    }
    IEnumerator EHardMode()
    {
        yield return new WaitForSeconds(0.35f);
        animator.SetBool("Running", true);
        RunningParticle.Play();
        yield return null;
    }
    public void stopRunning()
    {
        //playerrigidbody.velocity = new Vector3(0, 0, 0);
        animator.SetBool("Running", false);
        RunningParticle.Stop();
    }
    void CheckRunning()
    {
        if (animator.GetBool("Running"))
        {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);          
            Quaternion LookRot = Quaternion.LookRotation(Destination.position - transform.position);  
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookRot, Time.deltaTime * 150);
        }
    }
    void Recovering()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            SG_UIController.UIcont.RecoverImage.SetActive(false);
            animator.Play("Recovered");
            StopCoroutine(coroutine);
            SG_UIController.UIcont.TimeSlider.GetComponent<CanvasGroup>().alpha = 0;
            SG_UIController.UIcont.TimeSlider.value = 0;
            coroutine = null;
            isKnocked = false;
        }
    }
    public void ForceClip()
    {
        playerrigidbody.AddForce(-transform.forward * 50, ForceMode.Impulse);
    }
    public void ShowRecoverUI()
    {
        SG_UIController.UIcont.RecoverImage.SetActive(true);
        isKnocked = true;
        coroutine = StartCoroutine(ClockTimeOut());
    }
    public void SetUpClip()
    {
        animator.SetBool("Running", true);
        RunningParticle.Play();
    }
    public void SetUpColied()
    {
        SG_GoseguMovement.gosegumovement.TriggerColidBox.Colied = false;
    }

    public IEnumerator ClockTimeOut()
    {
        double startTime = 3f;
        float currentTime = 0f;
        SG_UIController.UIcont.TimeSlider.GetComponent<CanvasGroup>().alpha = 1;
        while (true)
        {
            currentTime += Time.unscaledDeltaTime;
            SG_UIController.UIcont.TimeSlider.value = currentTime * (float)(1 / startTime);
            if (currentTime >= startTime)
            {
                SG_UIController.UIcont.TimeSlider.GetComponent<CanvasGroup>().alpha = 0;
                SG_UIController.UIcont.TimeSlider.value = 0;
             //   SG_UIController.UIcont.RecoverUI.alpha = 0;
                SG_UIController.UIcont.RecoverImage.SetActive(false);
                animator.Play("NoRecovered");
                isKnocked = false;
                break;

            }
            yield return null;
        }
        yield return null;
    }
    public void SpawnJumpParticle()
    {
        Instantiate(JumpParticle, transform.position, transform.rotation);
    }
    public void spawnvault_Particle()
    {
        SG_ParticleManager.particleManager.SpawnVaultParticle();
    }
    public void spawnSlide_Particle()
    {
        SG_ParticleManager.particleManager.SpawnSlideParticle();
    }
}
