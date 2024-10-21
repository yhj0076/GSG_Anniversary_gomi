using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class SG_UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public  Canvas canvas;

    public Sprite[] Arrows;
    public Sprite[] Texts;
    
    public string[] HitAnimations; // 1. Hit 2. Knocked
    public CanvasGroup RecoverUI;
    public GameObject RecoverImage;
    public Slider TimeSlider;
    public Image[] arrowImages;
    public Image currentPos;
    public Image TextImage;
    public CanvasGroup trigger_canvasgroup;
    public CanvasGroup ArrowsGroup;
    public CanvasGroup SliderGroup;
    public Slider SpacebarSlider;
    public GameObject Push_SpaceBarImage;
    public GameObject ESCGroup;
    public AudioSource[] AudioSources;
    public AudioClip[] BGMClips;
    public Slider[] SoundSliders;
    public VideoClip[] CutScenes;
    public CanvasGroup GlideControlUI;
    bool bESC;
    public bool isESC;
    float CurrentTimeScale;
    public static SG_UIController UIcont;
    //public Slider TimeOutSlider;

    private void Awake()
    {
        UIcont = this;
    }
    private void Update()
    {
        ESC();
    }
    public void ESC()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isESC)
            {
                if (!bESC)
                {
                    bESC = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    
                    CurrentTimeScale = Time.timeScale;
                    Time.timeScale = 0;
                    Time.fixedDeltaTime = Time.timeScale * 0.02f;
                    ESCGroup.SetActive(true);
                    SoundSlidersSetUp();
                    


                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    bESC = false;
                    Time.timeScale = CurrentTimeScale;
                    Debug.Log(Time.timeScale);
                    Time.fixedDeltaTime = Time.timeScale * 0.02f;
                    ESCGroup.SetActive(false);
                }
            }
        }
    }
    void SoundSlidersSetUp()
    {
        for(int i = 0; i < SoundSliders.Length; i++)
        {
            SoundSliders[i].value = AudioSources[i].volume;
        }
    }
    public void SetVolume(int SoundType)
    {
        AudioSources[SoundType].volume = SoundSliders[SoundType].value;
        if(SoundType == 0)
        {
            AudioSources[2].volume = SoundSliders[SoundType].value;
        }
    }
    
}
