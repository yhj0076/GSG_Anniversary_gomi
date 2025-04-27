using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_NameSwitch : MonoBehaviour
{
    public GameObject talkManager;

    public GameObject teriaPark;
    public GameObject Gosegu;

    // Update is called once per frame
    void Update()
    {
        switch (talkManager.GetComponent<SA_TalkManager>().talkIndex)
        {
            case 1:
            case 3:
            case 5:
            case 6:
            case 7:
                Gosegu.SetActive(true);
                teriaPark.SetActive(false);
                break;
            default:
                Gosegu.SetActive(false);
                teriaPark.SetActive(true);
                break;
        }
    }
}
