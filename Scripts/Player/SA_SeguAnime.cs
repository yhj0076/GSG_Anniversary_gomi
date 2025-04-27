using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 행동 인덱스
 Idle : 0
 Walking : 1
 Jumping : 2
 AfterJump : 3
 */

public class SA_SeguAnime : MonoBehaviour
{
    Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    public void isLeft()
    {
        anime.SetBool("isLeft",true);
    }
    public void isRight()
    {
        anime.SetBool("isLeft", false);
    }

    public void conditionIndex(int index)
    {
        anime.SetInteger("conditionIndex",index);
    }
}
