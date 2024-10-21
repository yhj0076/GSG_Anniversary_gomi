using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class SA_SettingOn : MonoBehaviour
{
    public static SA_SettingOn instance;

    public GameObject Setting;
    public AudioMixer masterMixer;
    public Slider audioSlider1;
    public Slider audioSlider2;

    GameObject stageMan;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            stageMan = GameObject.Find("Stages");
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 세팅 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SecurityPlayerPrefs.GetFloat("volumeControl_BGM", -1) == -1)
        {
            audioSlider1.value = -24;
            SecurityPlayerPrefs.SetFloat("volumeControl_BGM", audioSlider1.value);
        }
        else
        {
            if (audioSlider1 != null)
            {
                audioSlider1.value = SecurityPlayerPrefs.GetFloat("volumeControl_BGM", -1);
            }
        }

        if (SecurityPlayerPrefs.GetFloat("volumeControl_SFX", -1) == -1)
        {
            audioSlider2.value = -24;
            SecurityPlayerPrefs.SetFloat("volumeControl_SFX", audioSlider2.value);
        }
        else
        {
            if (audioSlider2 != null)
            {
                audioSlider2.value = SecurityPlayerPrefs.GetFloat("volumeControl_SFX", -1);
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Setting.activeSelf)
            {
                SetOFF();
            }
            else
            {
                SetON();
            }
        }
    }

    public void SetON()
    {
        Setting.SetActive(true);
        if(SceneManager.GetActiveScene().name == "SA_Main Scene" || SceneManager.GetActiveScene().name == "SA_How to play")
        {
            Time.timeScale = 0;
            if (SceneManager.GetActiveScene().name == "SA_Main Scene")
            {
                int stageIndex = stageMan.GetComponent<SA_StageManager>().choice;
                var NowStage = stageMan.transform.GetChild(stageIndex);
                NowStage.GetComponent<AudioSource>().Pause();
                switch (stageIndex)
                {
                    case 0:
                        NowStage.GetComponent<SA_StereoType>().Paused = true;
                        break;
                    case 1:
                        NowStage.GetComponent<SA_DoctorGo>().Paused = true;
                        break;
                    case 2:
                        NowStage.GetComponent<SA_YeaYea>().Paused = true;
                        break;
                    case 3:
                        NowStage.GetComponent<SA_FishBreadRain>().Paused = true;
                        break;
                    case 4:
                        NowStage.GetComponent<SA_raindrop>().Paused = true;
                        break;
                    case 5:
                        NowStage.GetComponent<SA_OneChipController>().Paused = true;
                        break;
                    case 6:
                        NowStage.GetComponent<SA_jansangController>().Paused = true;
                        break;
                    case 7:
                        NowStage.GetComponent<SA_MuSeven>().Paused = true;
                        break;
                    case 8:
                        NowStage.GetComponent<SA_Nadaejima>().Paused = true;
                        break;
                    case 9:
                        NowStage.GetComponent<SA_JustMeSpring>().Paused = true;
                        break;
                }
            }
        }
    }



    public void SetOFF()
    {
        Setting.SetActive(false);
        if(SceneManager.GetActiveScene().name == "SA_Main Scene" || SceneManager.GetActiveScene().name == "SA_How to play")
        {
            Time.timeScale = 1;
            if (SceneManager.GetActiveScene().name == "SA_Main Scene")
            {
                int stageIndex = stageMan.GetComponent<SA_StageManager>().choice;
                var NowStage = stageMan.transform.GetChild(stageIndex);
                if(stageIndex == 8)
                {
                    if (!NowStage.GetComponent<SA_Nadaejima>().FirstSoundEnd)
                    {
                        NowStage.GetComponent<AudioSource>().Play();
                    }
                }
                else
                    NowStage.GetComponent<AudioSource>().Play();
                // FindObjectOfType<VideoPlayer>().Play();
                switch (stageIndex)
                {
                    case 0:
                        NowStage.GetComponent<SA_StereoType>().Paused = false;
                        break;
                    case 1:
                        NowStage.GetComponent<SA_DoctorGo>().Paused = false;
                        break;
                    case 2:
                        NowStage.GetComponent<SA_YeaYea>().Paused = false;
                        break;
                    case 3:
                        NowStage.GetComponent<SA_FishBreadRain>().Paused = false;
                        break;
                    case 4:
                        NowStage.GetComponent<SA_raindrop>().Paused = false;
                        break;
                    case 5:
                        Invoke("DelayPlay_OneChip",0.001f);
                        break;
                    case 6:
                        NowStage.GetComponent<SA_jansangController>().Paused = false;
                        break;
                    case 7:
                        Invoke("DelayPlay_Mu7",0.001f);
                        break;
                    case 8:
                        NowStage.GetComponent<SA_Nadaejima>().Paused = false;
                        break;
                    case 9:
                        NowStage.GetComponent<SA_JustMeSpring>().Paused = false;
                        break;
                }
            }
        }
    }

    void DelayPlay_OneChip()
    {
        int stageIndex = stageMan.GetComponent<SA_StageManager>().choice;
        var NowStage = stageMan.transform.GetChild(stageIndex);
        NowStage.GetComponent<SA_OneChipController>().Paused = false;
    }

    void DelayPlay_Mu7()
    {
        int stageIndex = stageMan.GetComponent<SA_StageManager>().choice;
        var NowStage = stageMan.transform.GetChild(stageIndex);
        NowStage.GetComponent<SA_MuSeven>().Paused = false;
    }

    public void AudioControlBGM()
    {
        SecurityPlayerPrefs.SetFloat("volumeControl_BGM", audioSlider1.value);
        if (SecurityPlayerPrefs.GetFloat("volumeControl_BGM",0) == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", SecurityPlayerPrefs.GetFloat("volumeControl_BGM", 0));
        } 
    }

    public void AudioControlSFX()
    {
        SecurityPlayerPrefs.SetFloat("volumeControl_SFX", audioSlider2.value);
        if (SecurityPlayerPrefs.GetFloat("volumeControl_SFX", 0) == -40f)
        {
            masterMixer.SetFloat("SFX", -80);
        }
        else
        {
            masterMixer.SetFloat("SFX", SecurityPlayerPrefs.GetFloat("volumeControl_SFX", 0));
        }
    }

    public void OnDropdownEvent(int index)
    {
        switch (index)
        {
            case 4:
                Screen.SetResolution(640,360,false);
                break;
            case 3:
                Screen.SetResolution(960, 540, false);
                break;
            case 2:
                Screen.SetResolution(1280, 720, false);
                break;
            case 1:
                Screen.SetResolution(1600, 900, false);
                break;
            case 0:
                Screen.SetResolution(1920, 1080, false);
                break;
        }
    }
}
