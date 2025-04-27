using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_PlayerController : MonoBehaviour
{
    public GameObject cam;
    public AudioClip ZhonyaSound;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    SA_HealthController healthCon;
    SA_SeguAnime anime;
    public bool isGrounded = false;

    public float JumpPower;
    public float maxSpeed;
    public int JumpCount = 0;
    public bool isTalking = false;

    bool gookja = false;
    public bool Zhonya;
    float Zhonya_time = 0;

    int unfreeze = 0;
    public bool cleared;
    // Start is called before the first frame update
    void Start()
    {
        unfreeze = 0;
        Zhonya_time = 0;
        Zhonya = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        healthCon = GetComponent<SA_HealthController>();
        anime = GetComponent<SA_SeguAnime>();
        gookja = false;
        cleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cleared == false)
        {
            if (Zhonya == false)
            {
                //Flipx();
                Jump();
                Move();
            }
            else
            {
                Zhonya_time += Time.deltaTime;
                if (Zhonya_time >= 2 || unfreeze >= 6)
                {
                    Zhonya_time = 0;
                    ZhonyaFalse();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) && unfreeze < 6)
                {
                    unfreeze++;
                }
            }
        }
        else
        {
            if (rigid.velocity.x > maxSpeed)
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeed * (-1))
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            }
        }
    }

    void Flipx()
    {
        /*if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }*/
        if (rigid.velocity.x > 0.1f&&rigid.velocity.y==0)
        {
            anime.isRight();
            anime.conditionIndex(1);
        }
        else if(rigid.velocity.x < -0.1f&&rigid.velocity.y==0)
        {
            anime.isLeft();
            anime.conditionIndex(1);
        }
        else if(rigid.velocity.x > -0.1f && rigid.velocity.x < 0.1f && rigid.velocity.y == 0 )
        {
            anime.conditionIndex(0);
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right*h*10, ForceMode2D.Impulse);
        if (h > 0)
        {
            anime.isRight();
        }
        else if (h < 0)
        {
            anime.isLeft();
        }

        //Max speed
        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        
        if (JumpCount > 1)
        {
            anime.conditionIndex(2);
        }
        else
        {
            if (rigid.velocity.x == 0 && rigid.velocity.y == 0)
            {
                anime.conditionIndex(0);
            }
            else if ((Mathf.Abs(rigid.velocity.x) > 0 && rigid.velocity.y == 0) || gookja)
            {
                anime.conditionIndex(1);
            }
        }
    }

    void Jump()
    {   
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount<2)
        {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(new Vector2(rigid.velocity.x, JumpPower));
            JumpCount++;
        }

        //Stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.1f || collision.transform.tag == "Platform")
        {
            isGrounded = true;
            JumpCount = 1;
        }
        if (collision.transform.name == "국자(Clone)")
        {
            gookja = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.1f || collision.transform.tag == "Platform")
        {
            isGrounded = true;
            JumpCount = 1;
        }
        if (collision.transform.name == "국자(Clone)")
        {
            gookja = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
        if (collision.transform.name == "국자(Clone)")
        {
            gookja = false;
        }
    }

    public void ZhonyaFalse()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Animator>().speed = 1;
        transform.GetChild(5).gameObject.SetActive(false);
        Zhonya = false;
    }

    public void ZhonyaTrue()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        GetComponent<Animator>().speed = 0;
        unfreeze = 0;
        transform.GetChild(5).gameObject.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(ZhonyaSound);
        Zhonya = true;
    }
}
