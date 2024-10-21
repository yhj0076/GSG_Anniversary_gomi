using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SA_SoundManagerForGameOver : MonoBehaviour
{
    public AudioClip BGM;
    AudioSource BgmAudioPlayer;

    float beforeVolume = 1;
    // Start is called before the first frame update
    void Start()
    {
        BgmAudioPlayer = GetComponent<AudioSource>();
        BgmAudioPlayer.loop = true;
        playMusic();
        DontDestroyOnLoad(gameObject);
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
        BgmAudioPlayer.volume = beforeVolume / 3;
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
