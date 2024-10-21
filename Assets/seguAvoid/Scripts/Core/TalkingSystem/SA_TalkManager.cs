using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SA_TalkManager : MonoBehaviour
{
    [SerializeField]
    public string[] talk;

    public Text talking;
    public int talkIndex = 0;
    private void OnEnable()
    {
        talkIndex = 0;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            talkIndex++;
        }

        if(talk.Length == talkIndex)
        {
            transform.parent.gameObject.SetActive(false);
            FindObjectOfType<SA_PlayerController>().isTalking = false;
        }
        else
        {
            talking.text = talk[talkIndex];
        }
        
    }
}
