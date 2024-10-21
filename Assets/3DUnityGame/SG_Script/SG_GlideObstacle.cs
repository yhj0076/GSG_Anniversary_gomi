using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_GlideObstacle : MonoBehaviour
{
    // Start is called before the first frame update
   // public float Height;
   /* GameObject ColiedPlayer;
    Vector3 ObjectPos;
    float UpperSpeed = 7;*/
    [SerializeField] Animator animator;
    public GameObject ParentGameObject;
    void Start()
    {
        animator = ParentGameObject.GetComponent<Animator>();
       // ColiedPlayer = GameObject.Find("gosegu");
      //  StartCoroutine(Init_Pos(Height));
       // StartCoroutine(Desytoying());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "gosegu")
        {
            //ColiedPlayer = other.gameObject;
            int tempnum = SG_LifeSystem.lifeSystem.CurrentHeartNum;
            if (tempnum > 0)
            {
                other.GetComponent<Animator>().SetTrigger("GlideHit");
                SG_LifeSystem.lifeSystem.Hit_Glitch();
                SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
              //  SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
                SG_LifeSystem.lifeSystem.CurrentHeartNum--;
            }
            else
            {
                //SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
                SG_LifeSystem.lifeSystem.Hearts[tempnum].sprite = SG_LifeSystem.lifeSystem.Transparent;
                SG_LifeSystem.lifeSystem.GlidingDeath();
            }
            StartCoroutine(Desytoy_By_Hit());
        }
    }
   /* IEnumerator Init_Pos(float FixY)
    {
        float CurrentY = 0;
        float DireY = ColiedPlayer.transform.position.y;
        animator.Play("Spawn");
        while (true)
        {
            ObjectPos = gameObject.transform.position;
            CurrentY = ObjectPos.y;
            if (CurrentY >= DireY - FixY)
                break;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                new Vector3(ObjectPos.x, DireY - FixY, ObjectPos.z), Time.deltaTime * UpperSpeed);
            yield return null;
        }
        


    }*/
  /*  IEnumerator Desytoying()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }*/
    IEnumerator Desytoy_By_Hit()
    {
     //   animator.Play("Destroy");
     //   yield return new WaitForSeconds(0.75f);
        Destroy(ParentGameObject);
        yield return null;
    }
}
