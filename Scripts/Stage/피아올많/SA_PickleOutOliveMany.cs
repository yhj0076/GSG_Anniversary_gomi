using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_PickleOutOliveMany : MonoBehaviour
{
    AudioSource soundPlayer;
    public GameObject QRcode;
    public GameObject egg;
    public GameObject mayo;
    //2.6초 문 차기
    //5.4초 이탈리안 BLT15cm 단품
    //8.0초 QR코드 on
    //11.4초 플랫브레드
    //15.5초 에그마요
    //23.0초 피아
    //23.8초 올많
    private void OnEnable()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
        Invoke("Door",2.6f);
        Invoke("Italian",5.4f);
        Invoke("BLT",5.8f);
        Invoke("QR",8.0f);
        Invoke("FlatBread",11.4f);
        Invoke("EggMayo",15.5f);
        Invoke("PickleOut",23.0f);
        Invoke("OliveMany",23.8f);
    }

    void Door()
    {
        transform.GetChild(0).GetComponent<SA_DoorBreak>().kick = true;
    }
    void Italian()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }
    void BLT()
    {
        transform.GetChild(1).GetComponent<SA_ItalianBLT>().drop = true;
    }
    void QR()
    {
        GameObject.Instantiate(QRcode, Vector3.zero, Quaternion.identity).transform.parent = transform;
    }
    void FlatBread()
    {
        transform.GetChild(2).gameObject.SetActive(true);
    }
    void EggMayo()
    {
        GameObject.Instantiate(egg, new Vector2(Random.Range(-4f,-2f),6.5f), Quaternion.identity).transform.parent = transform;
        GameObject.Instantiate(mayo, new Vector2(Random.Range(2f,4f),6.5f), Quaternion.identity).transform.parent = transform;
    }
    void PickleOut()
    {
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
    }
    void OliveMany()
    {
        transform.GetChild(5).gameObject.SetActive(true);
    }

    private void Update()
    {
        if (soundPlayer.isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        for (int i = 1; i < 6; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        Destroy(transform.GetChild(6).gameObject);
        Destroy(transform.GetChild(7).gameObject);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
