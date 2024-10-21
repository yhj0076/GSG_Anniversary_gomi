using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SG_ParticleManager : MonoBehaviour
{

    public GameObject[] HitParticles;
    public GameObject VaultParticle;
    public Transform vaultparticlePlace;
    public Transform slideparticlePlace;
    public ParticleSystem DashParticle;
    GameObject SpawnObject;
    // Start is called before the first frame update
    public static SG_ParticleManager particleManager;
    private void Awake()
    {
        particleManager = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnHitParticle(int index, Image Parent)
    {
        SpawnObject = Instantiate(HitParticles[index], new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        //SpawnObject.transform.parent = Parent.transform;
        SpawnObject.GetComponent<RectTransform>().SetParent(Parent.transform);
        SpawnObject.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 50, 0);
        SpawnObject.GetComponent<RectTransform>().transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        SpawnObject.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);



    }
    public void SpawnVaultParticle()
    {
        Instantiate(VaultParticle, vaultparticlePlace.position, vaultparticlePlace.rotation);
    }
    public void SpawnSlideParticle()
    {
        Instantiate(VaultParticle, slideparticlePlace.position, slideparticlePlace.rotation);
    }

    public void DashVFXOn()
    {
        DashParticle.Play();
    }
    public void DashVFXOff()
    {
        DashParticle.Stop();
    }
}
