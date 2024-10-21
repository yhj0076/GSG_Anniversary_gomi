using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_SaveBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform SavePos;
    public GameObject SaveObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "gosegu")
        {
            StartCoroutine(SavePointDestroy());
        }
    }
    IEnumerator SavePointDestroy()
    {
        SG_LifeSystem.lifeSystem.SetUpLife();
        SG_GameManager.gameManager.Save(new Vector3(SavePos.position.x + 1.5f, SavePos.position.y, SavePos.position.z));
        SaveObject.GetComponent<Animator>().Play("Saved");
        SG_PlaySFX.sgplaySFX.playSFX(5);
        yield return new WaitForSeconds(0.25f);
        Destroy(SavePos.gameObject);
    }
}
