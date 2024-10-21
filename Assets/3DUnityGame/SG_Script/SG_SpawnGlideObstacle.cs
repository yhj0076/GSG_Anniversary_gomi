using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_SpawnGlideObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float Height;
    GameObject ColiedPlayer;
    Vector3 ObjectPos;
    float UpperSpeed = 7;
    public Animator animator;
    void Start()
    {
        ColiedPlayer = GameObject.Find("gosegu");
        StartCoroutine(Init_Pos(Height));
        StartCoroutine(Desytoying());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Init_Pos(float FixY)
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



    }
    IEnumerator Desytoying()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
}
