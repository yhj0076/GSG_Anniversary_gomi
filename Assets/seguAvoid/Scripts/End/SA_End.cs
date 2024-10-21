using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class SA_End : MonoBehaviour
{
    VideoPlayer videoPlayer;
    GameObject SAsound;
    GameObject SAsound_Clone;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        SAsound = GameObject.Find("SoundManager");
        SAsound_Clone = GameObject.Find("SoundManager(Clone)");
        if (SAsound != null)
        {
            Destroy(SAsound);
        }
        else if(SAsound_Clone != null)
        {
            Destroy(SAsound_Clone);
        }
        SecurityPlayerPrefs.SetInt("SA_Finish",1);
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer.isPlaying == false)
        {
            SceneManager.LoadScene(5);
        }
    }
}
