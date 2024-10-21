using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SA_ScoreLoad : MonoBehaviour
{
    public Text Rank;
    public Text BESTScore;
    // Start is called before the first frame update
    void Start()
    {
        SecurityPlayerPrefs.SetInt("SA_SeguDiedCount", SecurityPlayerPrefs.GetInt("SA_SeguDiedCount", 0) + 1);  // 죽은 횟수 세기
        int LastScore = SecurityPlayerPrefs.GetInt("LastScore",-1)-1;
        if (LastScore > 11)
        {
            Rank.text = "BOSS";
        }
        else
        {
            Rank.text = LastScore + "/10";
        }
        SA_SoundManager.instance.musicBack();
    }
}
