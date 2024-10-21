using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tm_DodgeParkour : MonoBehaviour
{
    
    // Start is called before the first frame update
    public string animations; // 0 : 점프, 1 : 슬라이딩, 2 : 뛰어넘기, 3 : 옆으로 Dodge
    public GameObject Dodge_HairClip;
    public Transform SpawnPos;
    float WaitToParkour = 0.05f; // 0 : 0.33f, 1 : 0.09f, 2 : 0.4f
    Vector3 Pos;
    Vector3 DodgePos;
    Animator animator;
    float GrappleSpeed = 1f;
    float Dodgevalue = 2f;
    bool playing;
    void Start()
    {
        animator = GetComponent<Animator>();
        Pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            playing = true;
            DodgePos = transform.position + transform.right * Dodgevalue;
            StartCoroutine(Parkour());
        }
    }

    IEnumerator Parkour()
    {
        Instantiate(Dodge_HairClip, SpawnPos.position, SpawnPos.rotation);
        yield return new WaitForSeconds(2f);
        animator.Play(animations);
        yield return new WaitForSeconds(WaitToParkour);
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, DodgePos, GrappleSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, DodgePos) <= 0.2f)
            {
                yield return new WaitForSeconds(2.0f);
                transform.position = Pos;
                playing = false;
                break;

            }
            yield return null;
        }

    }
}
