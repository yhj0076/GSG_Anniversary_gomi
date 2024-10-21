using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class SG_HardModeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 HardModeStartPos = new Vector3(2210f, 292.7f, -3439.9f);
    GameObject player;
    public CanvasGroup MMDPanel;
    public VideoPlayer videoplayer;
    public AudioSource MMDAudio;
    public RawImage AudioRawImage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "gosegu")
        {
            player = other.gameObject;
            StartCoroutine(Play_MMD_Before_HardMode());
        }
    }

    IEnumerator Play_MMD_Before_HardMode()
    {
        // Camera Off
        SG_UIController.UIcont.isESC = true;
        SG_RunningGame.runninggame.stopRunning();
        SG_UIController.UIcont.AudioSources[0].mute = true;
        SG_UIController.UIcont.AudioSources[1].mute = true;
        SG_Camera.sgcamera.FadingOut();
        // Play MMD Video
        MMDPanel.alpha = 1;
        if (videoplayer != null)
        {
            videoplayer.clip = SG_UIController.UIcont.CutScenes[SG_GameManager.gameManager.GameMode];
            videoplayer.Prepare();
            WaitForSeconds waitforseconds = new WaitForSeconds(1f);
            while (!videoplayer.isPrepared)
            {
                yield return waitforseconds;
                break;
            }
            AudioRawImage.texture = videoplayer.texture;
            videoplayer.Play();
            MMDAudio.Play();
        }
        //Stop Running, SavePos Change, GameMode Change
        
        

        float duration = (float)videoplayer.clip.length;
        yield return new WaitForSeconds(duration);
        SG_Camera.sgcamera.FadingOut();
        MMDPanel.alpha = 0;
        // Camera On
        // 
        //yield return new WaitForSeconds(1.5f);
        player.transform.position = HardModeStartPos;
        SG_GameManager.gameManager.GameMode = 1;
        SG_LifeSystem.lifeSystem.HeartTotalNum = 3;
        SG_GameManager.gameManager.Save(HardModeStartPos);

        SG_UIController.UIcont.AudioSources[0].mute = false;
        SG_UIController.UIcont.AudioSources[1].mute = false;

        SG_UIController.UIcont.AudioSources[0].clip = SG_UIController.UIcont.BGMClips[2];
        SG_UIController.UIcont.AudioSources[0].Play();

        
        SG_LifeSystem.lifeSystem.SetUpLife();

        SG_RunningGame.runninggame.startHardMode();
        SG_GameManager.gameManager.EasyModeMap.SetActive(false);
        SG_UIController.UIcont.isESC = false;
        yield return null;
    }
}
