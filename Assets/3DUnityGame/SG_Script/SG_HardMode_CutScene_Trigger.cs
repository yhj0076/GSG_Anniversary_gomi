using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class SG_HardMode_CutScene_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 GlidingGameStartPos = new Vector3(6490f, -2f, 36.5f);
    //public PlayableDirector Director;
   // public GameObject CutScene_Stuff;
    //public GameObject OriginCamera;
   // public GameObject CutSceneCamera;
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
            StartCoroutine(Play_CutScene_Before_GlidingGame());
        }
    }

    IEnumerator Play_CutScene_Before_GlidingGame()
    {
        // Camera Off
        SG_UIController.UIcont.isESC = true;
        SG_RunningGame.runninggame.stopRunning();
        //player.GetComponent<Rigidbody>().isKinematic = true;
       // player.GetComponent<Rigidbody>().detectCollisions = false;
        SG_UIController.UIcont.AudioSources[0].mute = true;
        SG_UIController.UIcont.AudioSources[1].mute = true;
        SG_Camera.sgcamera.FadingOut();
        // Play MMD Video
       // CutScene_Stuff.SetActive(true);
       // OriginCamera.SetActive(false);
       // CutSceneCamera.SetActive(true);
       // yield return new WaitForSeconds(1f);
        
       // Director.Play();
      //  float duration = (float)Director.playableAsset.duration;
       // yield return new WaitForSeconds(duration);
       //  SG_Camera.sgcamera.FadingOut();
        // Camera On
        // 
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
        float duration = (float)videoplayer.clip.length;
        yield return new WaitForSeconds(duration);
        SG_Camera.sgcamera.FadingOut();
        MMDPanel.alpha = 0;
        // player.GetComponent<Rigidbody>().detectCollisions = true;
        //OriginCamera.SetActive(true);
        //CutSceneCamera.SetActive(false);
        //CutScene_Stuff.SetActive(false);
        SG_GameManager.gameManager.GameType = 1;
        SG_GameManager.gameManager.Save(GlidingGameStartPos);
        
        SG_UIController.UIcont.AudioSources[0].mute = false;
        SG_UIController.UIcont.AudioSources[1].mute = false;
        
        player.transform.position = GlidingGameStartPos;
        player.transform.eulerAngles = new Vector3(0, 90, 0);
        SG_LifeSystem.lifeSystem.SetUpLife();
        SG_ParaGliding.paraGliding.ParaGlidingGame_Init();
        
        Clouds.SG_CameraCloud.cameracloud.CameraCloudOn();
        SG_Camera.sgcamera.canmovecamera = true;
        SG_UIController.UIcont.canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        SG_UIController.UIcont.AudioSources[0].clip = SG_UIController.UIcont.BGMClips[1];
        SG_UIController.UIcont.AudioSources[0].Play();

        SG_GameManager.gameManager.HardModeMap.SetActive(false);
        SG_UIController.UIcont.isESC = false;
        // yield return new WaitForSeconds(1f);
        // player.GetComponent<Rigidbody>().isKinematic = false;
        //player.GetComponent<Rigidbody>().detectCollisions = true;

    }
}


