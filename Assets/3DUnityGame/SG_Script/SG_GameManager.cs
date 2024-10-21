using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class Player
{
    public Vector3 Pos; // 세이브 위치
    public int LifeNum;// 리이프 수
    public int GameMode;
    public int GameType;
    public Player(Vector3 pos, int lifenum, int gamemode, int gametype)
    {
        Pos = pos;
        LifeNum = lifenum;
        GameMode = gamemode;
        GameType = gametype;
    }

}
public class SG_GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 SavePoint;
    public static Vector3 StartRot;
    FullScreenMode FullScreen;
    public Player player;
    [SerializeField] GameObject gosegu;
    public int GameMode; // 0 : (Rhythm Game) Easy Mode, 1 :(Rhythm Game) HardMode
    public int GameType; // 0 : Rhythm Game, 1 :Paragliding Game
    public static SG_GameManager gameManager;
    public GameObject EasyModeMap;
    public GameObject HardModeMap;
    private void Awake()
    {
        gameManager = this;
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gosegu = GameObject.Find("gosegu");
        Init_Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetSavePoint(Vector3 nextSavePoint)
    {
        SavePoint = nextSavePoint;
    }

    public void Save(Vector3 Pos)
    {
        StartCoroutine(saving(Pos));
    }
    IEnumerator saving(Vector3 pos)
    {
        int lifenum = SG_LifeSystem.lifeSystem.HeartTotalNum;
        player = new Player(pos, lifenum, GameMode, GameType);

        string tempFile = JsonConvert.SerializeObject(player);
        File.WriteAllText(Application.dataPath + "/StreamingAssets/player.json", tempFile);
        yield return null;
    }

    public void Init_Load()
    {
        string tempFile = File.ReadAllText(Application.dataPath + "/StreamingAssets/player.json");
        player = JsonConvert.DeserializeObject<Player>(tempFile);

        //Screen.SetResolution(1920, 1080, FullScreen);

        gosegu.transform.position = player.Pos; // SetUp Position     
        SG_LifeSystem.lifeSystem.HeartTotalNum = player.LifeNum; // SetUp LifeSystem
        GameMode = player.GameMode;
        GameType = player.GameType;
        if(GameMode == 1 && GameType != 1)
        {
            SG_UIController.UIcont.AudioSources[0].clip = SG_UIController.UIcont.BGMClips[2];
        }
        else {
            SG_UIController.UIcont.AudioSources[0].clip = SG_UIController.UIcont.BGMClips[GameType];
        }
        SG_UIController.UIcont.AudioSources[0].Play();
        SG_LifeSystem.lifeSystem.SetUpLife();
        if(GameType == 0) // Rhythm Game
        {
            SG_RunningGame.runninggame.RhythmGame_Init();
            if (GameMode == 1)
            {
                EasyModeMap.SetActive(false);
            }
        }
        else  // Paragliding Game
        {
            EasyModeMap.SetActive(false);
            HardModeMap.SetActive(false);
            SG_ParaGliding.paraGliding.ParaGlidingGame_Init();
            Clouds.SG_CameraCloud.cameracloud.CameraCloudOn();
            SG_Camera.sgcamera.canmovecamera = true;
            SG_UIController.UIcont.canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

    }

    public void Death_Load()
    {
        string tempFile = File.ReadAllText(Application.dataPath + "/StreamingAssets/player.json");
        player = JsonConvert.DeserializeObject<Player>(tempFile);
        
        gosegu.transform.position = player.Pos;// SetUp Position
        gosegu.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));// SetUp Rotation
      //  SG_LifeSystem.lifeSystem.HeartTotalNum = player.LifeNum; // SetUp LifeSystem
      // GameMode = player.GameMode;
      //  GameType = player.GameType;
    }
}
