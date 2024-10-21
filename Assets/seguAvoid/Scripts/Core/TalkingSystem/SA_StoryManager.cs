using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_StoryManager : MonoBehaviour
{
    public static SA_StoryManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 스토리 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    public GameObject FarFarAway;
    public GameObject WhenWhere;

    public GameObject TalkingWindow;

    // Start is called before the first frame update
    void Start()
    {
        FarFarAway.SetActive(true);
        if(WhenWhere != null)
        {
            WhenWhere.SetActive(true);
        }
        Invoke("EnableWindow", Mathf.PI + 0.5f);
    }

    void EnableWindow()
    {
        TalkingWindow.SetActive(true);
    }
}
