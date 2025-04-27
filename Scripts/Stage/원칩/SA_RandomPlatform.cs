using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_RandomPlatform : MonoBehaviour
{
    public GameObject normal_Platform;
    Vector2[] PlatformPos = new Vector2[5];

    int choice = -1;
    // Start is called before the first frame update
    void OnEnable()
    {
        PlatformPos[0] = new Vector2(0+10.28f, 1.65f);            //    0      1
        PlatformPos[1] = new Vector2(6+10.28f, 1.65f);            //
        PlatformPos[2] = new Vector2(3+10.28f,   0f);              //       2
        PlatformPos[3] = new Vector2(0+10.28f,-1.65f);           //
        PlatformPos[4] = new Vector2(6+10.28f,-1.65f);           //    3      4

        choice = Random.Range(0,5);
        for(int i = 0; i < 5; i++)
        {  
            var NPlatform = GameObject.Instantiate(normal_Platform, PlatformPos[i], Quaternion.identity).transform.parent = transform;
            NPlatform.tag = "Platform";
        }
    }

    private void OnDisable()
    {
        int a = transform.childCount-1;
        for(int i = a; i>=0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
