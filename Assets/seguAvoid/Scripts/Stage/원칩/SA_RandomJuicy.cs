using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_RandomJuicy : MonoBehaviour
{
    public GameObject Juicy;
    Vector2[] PlatformPos = new Vector2[5];

    int choice = -1;
    int beforeChoice = -1;
    int beforebeforeChoice = -1;
    Vector2 destination;
    // Start is called before the first frame update
    void OnEnable()
    {
        PlatformPos[0] = new Vector2(-0.68f, 2.9f);            //    0      1
        PlatformPos[1] = new Vector2(5.32f,  2.9f);             //
        PlatformPos[2] = new Vector2(2.3f,   1.2f);              //       2
        PlatformPos[3] = new Vector2(-0.68f,-0.4f);           //
        PlatformPos[4] = new Vector2(5.32f, -0.4f);            //    3      4

        do
        {
            choice = Random.Range(0, 5);
        } while (choice == beforeChoice || choice == beforebeforeChoice);
        destination = PlatformPos[choice];
        var JPlatform = GameObject.Instantiate(Juicy, new Vector2(PlatformPos[choice].x,-7.04f), Quaternion.identity).transform.parent = transform;
        JPlatform.tag = "Platform";
    }

    private void Update()
    {
        transform.GetChild(0).position = Vector2.Lerp(transform.GetChild(0).position,destination,0.08f);
    }
    private void OnDisable()
    {
        Destroy(transform.GetChild(0).gameObject);
        beforebeforeChoice = beforeChoice;
        beforeChoice = choice;
    }
}
