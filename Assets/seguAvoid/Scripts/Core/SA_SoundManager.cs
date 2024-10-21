using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SA_SoundManager : MonoBehaviour
{
    public static SA_SoundManager instance;
    public AudioClip BGM;
    AudioSource BgmAudioPlayer;

    float beforeVolume = 1;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        BgmAudioPlayer = GetComponent<AudioSource>();
        BgmAudioPlayer.loop = true;
        playMusic();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            Destroy(gameObject);
        }
    }

    public void playMusic()
    {
        BgmAudioPlayer.clip = BGM;
        BgmAudioPlayer.Play();
        BgmAudioPlayer.loop = true;
    }

    public void pauseMusic()
    {
        BgmAudioPlayer.Pause();
    }

    public void musicDown()
    {
        beforeVolume = BgmAudioPlayer.volume;
        BgmAudioPlayer.volume = beforeVolume/3;
    }

    public void musicDown_Zero()
    {
        beforeVolume = BgmAudioPlayer.volume;
        BgmAudioPlayer.volume = -80;
    }
    public void musicBack()
    {
        BgmAudioPlayer.volume = beforeVolume;
    }
}
