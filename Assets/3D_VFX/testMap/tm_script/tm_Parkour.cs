using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tm_Parkour : MonoBehaviour
{
    // Start is called before the first frame update
    public string animations; // 0 : 점프, 1 : 슬라이딩, 2 : 뛰어넘기, 3 : 옆으로 Dodge
    public Transform HitObject;
    public float WaitToParkour; // 0 : 0.33f, 1 : 0.09f, 2 : 0.4f
    Vector3 Pos;
    Animator animator;
    float GrappleSpeed;
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
            GrappleSpeed = Vector3.Distance(transform.position, HitObject.position) - 1;
            float tempY = HitObject.position.y - transform.position.y;
            if (tempY >= 2)
                GrappleSpeed += tempY;
            StartCoroutine(Parkour());
        }
    }

    IEnumerator Parkour()
    {
        animator.Play(animations);
        yield return new WaitForSeconds(WaitToParkour);
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, HitObject.position, GrappleSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, HitObject.position) <= 0.2f)
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
