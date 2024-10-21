using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_SpawnGlideObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public int ObjectType; // 0 : Up, 1 : Forward, 2 : Balloon, 3 : Wall, 4 : Pigeons, 5 : AirPlane
    Vector3 PlayerPos;
    private float PlusY;
    private float PlusRotY;
    private float RotValutY = 180;
    private float ValueY = 7f;
    // GameObject SpawnObject;
    float DIst; 
    void Start()
    {
        DIst = SG_ParaGliding.paraGliding.GlideDistance[ObjectType];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gosegu")
        {
            PlayerPos = other.gameObject.transform.position;
            MoveToYAxis();
            Vector3 tempV = SG_ParaGliding.paraGliding.GlideObjectRots[ObjectType];
            tempV.y += PlusRotY;          
            Instantiate(SG_ParaGliding.paraGliding.GlideObjects[ObjectType], new Vector3(PlayerPos.x + DIst, PlayerPos.y - 10, PlayerPos.z + PlusY), 
            Quaternion.Euler(tempV));
        }
    }
    void MoveToYAxis()
    {
        //int tempRanNum = Random.Range(0, 2);
        int tempRanNum;
        if (PlayerPos.z <= 36.5) // Right
            tempRanNum = 1;
        else
            tempRanNum = 0;

        switch (ObjectType)
        {
            
            case 3:
                //PlusY = Random.Range(0, 2);
                //Debug.Log(tempRanNum);
                if (tempRanNum == 0)// Right
                {
                    PlusY = -ValueY;
                }
                else // Left
                {
                    PlusY = ValueY;
                }
                break;
            case 5:
               // Debug.Log(tempRanNum);
                if (tempRanNum == 1)// Left
                {
                    PlusRotY = RotValutY;
                }          
                break;
            default:
                break;
            
        }
    }
}
