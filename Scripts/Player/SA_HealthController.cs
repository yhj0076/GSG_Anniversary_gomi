using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_HealthController : MonoBehaviour
{
    public GameObject cam;
    public GameObject stage;
    public GameObject reviveAnime;
    GameObject BGM;

    public int Maxhealth;
    public int health;
    bool revived;
    bool druged;
    AudioSource soundManager;
    public AudioClip hurt;
    public AudioClip re;
    public enum PLAYER_STATE
    {
        PS_NONE,
        PS_POWWWER,
        PS_DIE
    }

    public PLAYER_STATE state
    {
        get;
        private set;
    }

    private void Awake()
    {
        switch (SecurityPlayerPrefs.GetInt("SA_SeguDiedCount", 0))
        {
            case 0:
                Maxhealth = 5;
                health = 1;
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 1:
                Maxhealth = 5;
                break;
            case 2: 
            case 3:
                Maxhealth = 6;
                break;
            case 4:
            case 5:
                Maxhealth = 7;
                break;
            case 6:
            case 7:
                Maxhealth = 8;
                break;
            case 8:
            case 9:
                Maxhealth = 9;
                break;
            default:
                Maxhealth = 10;
                break;
        }
    }

    private void Start()
    {
        revived = false;
        druged = false;
        if (SecurityPlayerPrefs.GetInt("SA_SeguDiedCount", 0) != 0)
        {
            health = Maxhealth;
        }
        soundManager = GetComponent<AudioSource>();
        BGM = GameObject.Find("SoundManager");
        if (BGM == null)
        {
            BGM = GameObject.Find("SoundManager(Clone)");
        }
    }

    private void Update()
    {
        if(health>Maxhealth)
        {
            health = Maxhealth;
        }
    }

    public void Damaged()
    {
        if (state != PLAYER_STATE.PS_POWWWER)
        {
            //StageManager_SA.instance.hit = true;
            state = PLAYER_STATE.PS_POWWWER;
            health -= 1;
            soundManager.PlayOneShot(hurt);
            SA_UIManager.instance.healthCheck(health);
            if (health <= 0)
            {
                health = 0;
                if (SecurityPlayerPrefs.GetInt("SA_SeguDiedCount",0)>=5 && revived == false)
                {
                    //부활
                    BGM.GetComponent<SA_SoundManager>().pauseMusic();
                    soundManager.Play();
                    transform.GetComponent<SA_PlayerController>().ZhonyaFalse();
                    transform.GetComponent<SA_PlayerController>().Zhonya = false;
                    transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                    stage.SetActive(false);
                    startReviveAnime();
                    Invoke("revive", 6f);
                    soundManager.PlayOneShot(re);
                }
                else
                {
                    SA_StageManager.instance.StopCoroutine("WasPlayerHurt");
                    state = PLAYER_STATE.PS_DIE;
                    SecurityPlayerPrefs.SetInt("LastScore", SA_StageManager.instance.choice-1);
                    
                    Die();
                }
            }
            else if (health < 2&&druged == false)
            {
                stage.GetComponent<SA_StageManager>().Big_hurt = true;
                druged = true;
            }
            StartCoroutine("hurtEffect");
            Invoke("EffectComeback", 1);
        }
    }

    void startReviveAnime()
    {
        reviveAnime.SetActive(true);
        Invoke("InvokeReviveJump",4f);
    }

    void InvokeReviveJump()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        transform.position = new Vector3(0, -3, 0);
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(40,500));
    }

    void revive()
    {
        Debug.Log("댕같이 부활");
        health = 3;
        SA_UIManager.instance.healthCheck(health);
        state = PLAYER_STATE.PS_NONE;
        //SA_UIManager.instance.Health(health);

        BGM.GetComponent<SA_SoundManager>().playMusic();
        GameObject.Find("Main Camera").GetComponent<SA_CamShake>().Shake = false;
        if (SA_StageManager.instance.isSpinned > 0)
        {
            SA_StageManager.instance.isSpinned = 0;
        }
        SA_StageManager.instance.choice--;
        stage.GetComponent<SA_StageManager>().Big_hurt = false;
        stage.SetActive(true);
        revived = true;
        reviveAnime.SetActive(false);
    }

    IEnumerator hurtEffect()
    {
        transform.GetComponent<SpriteRenderer>().material.color = Color.red;
        FindObjectOfType<SA_CamShake>().Shake = true;
        yield return new WaitForSeconds(0.03f);
        transform.GetComponent<SpriteRenderer>().material.color = Color.gray;
        FindObjectOfType<SA_CamShake>().Shake = false;
    }
    void EffectComeback()
    {
        state = PLAYER_STATE.PS_NONE;
        transform.GetComponent<SpriteRenderer>().material.color = Color.white;
    }

    public void Heal()
    {
        health = 3;
        SA_UIManager.instance.healthCheck(health);
    }

    public void Die()
    {
        SA_GameManager.instance.GameOver();
    }
}
