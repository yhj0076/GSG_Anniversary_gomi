using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_HairClipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    bool BHairClipMove;
    float Speed = 10f;
    Vector3 Dir;
    Quaternion Quat;
    void Start()
    {
        StartCoroutine(SelfDestroy());
        Transform TempPlayer = GameObject.Find("gosegu").transform;
        Transform TempDist = GameObject.Find("Hard Mode Destination").transform;
        Dir = transform.position + (TempPlayer.position - TempDist.position) * 3;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BHairClipMove)
            goStraight();
        
    }

    void goStraight()
    {
        
      //  Quat = Quaternion.Euler(Dir);
        transform.position = Vector3.MoveTowards(transform.position, Dir, Time.deltaTime * Speed);
    }
    public void HairClipTrue()
    {
        BHairClipMove = true;
    }
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
