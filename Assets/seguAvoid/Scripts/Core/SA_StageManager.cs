 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*      들어가는 장애물들

0. 화면이 거꾸로라 불편하신가요?
1. ㅔㅔㅔ with 비챤(난이도 하향 or 삭제)
2. 아잇 개 with 징버거(삭제)
3. 눼눼(유지) --> 마지막 큰게 바닥을 찍도록
4. 마시마싯는(유지) --> 붕어빵 3개로 늘리기
5. 즙나기(유지) --> 떨어질 때 눈물이 터지도록
6. 닥터고(속도 상승 필요) --> 바로 나오지 말고 체력 위험할 때 퀴즈 식으로
7. 나대지마(난이도 유지)
8. 원칩(난이도 유지)
9. 잔상입니다만(유지)
10. 무7련
11. 피아올많(삭제)
12. 오렌지 오렌지(삭제)

보스 스테이지
로봇 히죽구가 입에서 레이저 쏘는 식. 위에는 세균단이 타고 있다.
레이저 어느정도 발사 후 현타가 오면 발사하는 형식
마우스로 발사? 이거 살릴까 생각해보자.

추가되었으면 하는 것
* 나만 봄 신기전(벚꽃도 뭐고 다 필요없어~ (발사 후 )나만 봄~)
  [구현] : 오른쪽에서 신기전 나오고 위로 쏘고 빠져
  특정 구역 제외하고 화살 쏟아내 굳
* 트리가드 --> 밑에 선 쫙 그어서 점프하는 식 (https://youtu.be/wPy5cALN38o 07:05:18~07:05:22)
* 실버버튼(추가 확정) --> 12조각 나눠서 중앙에서 세구님 향해서 날아오도록
* 별주부전 하이라이트(왁 : 고셰구~~~ 고 : 이야아아아아아아 하고 도망가는 파트. 고튜브 7:05~7:12 음원)
  [구현] : 등딱지 계속 던져


/* 쉬는 시간 대폭 줄여야 함.ㅁ*/
 

public class SA_StageManager : MonoBehaviour
{
    public static SA_StageManager instance;

    int nowStage = 2;
    public int choice = 1;
    public bool Big_hurt = false;
    int temp_Stage = -1;


    public GameObject Player;
    // public bool hit = false;
    public int score = 0;
    public bool end = false;
    public GameObject SoundPlayer;
    public AudioClip doctorGo;

    public string NowPattern = "NULL";

    GameObject soundManager;
    public GameObject cam;
    public GameObject Added;
    public int isSpinned = 0;
    public string inState = "";
    //bool isScoreGiven = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            soundManager = GameObject.Find("SoundManager");
            if(soundManager == null)
            {
                GameObject.Instantiate(SoundPlayer, Vector3.zero, Quaternion.identity);
                soundManager = GameObject.Find("SoundManager(Clone)");
                Big_hurt = false;
                temp_Stage = -1;
            }
            else
            {
                soundManager.SetActive(true);
            }

            if(SecurityPlayerPrefs.GetInt("BossCleared", 0)==1)
            {
                choice = 12;
            }
            else if(SecurityPlayerPrefs.GetInt("SA_SeguDiedCount", 0) == 0)
            {
                choice = 1;
            }
            else
            {
                choice = 2;
            }
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 스테이지 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    public enum STAGE_STATE
    {
        SS_NONE,    // 아무것도 아님
        SS_THINK,   // 생각중
        SS_DO       // 실행중
    }

    public STAGE_STATE state
    {
        get;
        set;
    }

    private void OnEnable()
    {
        state = STAGE_STATE.SS_NONE;
        //hit = true;
        isSpinned = 0;

    }

    private void OnDisable()
    {
        for(int i = 0; i < transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Think();
        WhenStageEnd();
        switch (state)
        {
            case STAGE_STATE.SS_NONE:
                inState = "NONE";
                break;
            case STAGE_STATE.SS_THINK:
                inState = "THINK";
                break;
            case STAGE_STATE.SS_DO:
                inState = "DO";
                break;
        }

        // 보스 스킵버전
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.O))
        {
            choice = 12;
        }
    }

    void Think()
    {
        
        if (state == STAGE_STATE.SS_THINK)
        {
            if (Big_hurt&&temp_Stage == -1&&nowStage < 12)
            {
                temp_Stage = nowStage+1;
                choice++;
                nowStage = 1;
                
                Big_hurt = false;
            }
            else
            {
                if (SecurityPlayerPrefs.GetInt("SA_SeguDiedCount",0) == 2 && nowStage == 6)
                {
                    temp_Stage = nowStage+1;
                    choice++;
                    nowStage = 0;
                }
                else
                {
                    if (temp_Stage != -1)
                    {
                        nowStage = temp_Stage;
                        temp_Stage = -1;
                    }
                    else
                    {
                        choice++;
                        nowStage = choice;
                    }
                }
            }



            switch (nowStage)
            {
                case 0:
                    NowPattern = "고정관념";
                    break;
                case 1:
                    NowPattern = "닥터고";
                    /*
                     * 기믹 고민
                     * 마라탕 그림
                     * 밑에 떨어뜨리는 
                     */
                    break;
                case 2:
                    NowPattern = "튜토리얼";
                    break;
                case 3:
                    NowPattern = "눼눼";
                    /* 앞 부분 눼눼 삭제
                     * 
                     */
                    break;
                case 4:
                    NowPattern = "붕어빵";
                    /*
                     아아아부터 시작하고
                     난이도 상승
                     */
                    break;
                case 5:
                    NowPattern = "즙나기";
                    /*아흑 죄송 삭제*/
                    break;
                case 6:
                    NowPattern = "원칩";
                    /*
                     쥬시쿨 랜덤(희미해졌다가 나오는 걸로)
                     불꽃 세번 쏘는 걸로
                     소리를 세번 지르는 걸로
                     */
                    break;
                case 7:
                    NowPattern = "잔상입니다만";
                    /*
                     경고 사라지자마자 칼 나오는 걸로
                    칼 흩뿌리기
                     */
                    break;
                case 8:
                    NowPattern = "무7련";
                    /*
                     음원 소스 길이 줄이기
                     */
                    break;
                case 9:
                    NowPattern = "나대지마";
                    /*
                     국자 속도 증가
                     국지 나오기 직전에 자 뒤졌습니다로..
                     */
                    break;
                case 10:
                    NowPattern = "나만봄";
                    /*좌우 속도 상승*/
                    break;
                case 11:
                    NowPattern = "트리가드";
                    break;
                case 12:
                    NowPattern = "팬섭";
                    break;
                case 13:
                    NowPattern = "워닝";
                    break;
                case 14:
                    NowPattern = "별주부전";
                    /* 이걸 보스전으로
                     * 간 5개를 먹으면 데미지를 주는 걸로
                     * 세균단이 조종하는 섬씽 로봇...?
                     */
                    SecurityPlayerPrefs.SetInt("BossCleared",1);
                    break;
                case 15:
                    NowPattern = "클리어";
                    break;
                default:
                    SA_GameManager.instance.Clear();
                    break;
            }
            transform.GetChild(nowStage).gameObject.SetActive(true);
            if(nowStage != 12)
            {
                soundManager.GetComponent<SA_SoundManager>().musicDown();
            }
            state = STAGE_STATE.SS_DO;
            if(nowStage == 0&& choice == 1)
            {
                SA_UIManager.instance.Score(0);
            }
            else
            {
                SA_UIManager.instance.Score(choice-2);
            }
        }
    }

    void WhenStageEnd()
    {
        if(state == STAGE_STATE.SS_NONE)
        {
            StartCoroutine("WasPlayerHurt");
        }
    }

    IEnumerator WasPlayerHurt()
    {
        //if (hit == false && isScoreGiven == false)
        //{
        //    // 100점 추가
        //    //Invoke("AddScore",2);
        //    if (beforeIndex != 3)
        //    {
        //        AddScore();
        //    }
        //    if(beforebeforeIndex == 3)
        //    {
        //        AddScore();
        //    }
        //}
        if (isSpinned == 0)
        {
            cam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        soundManager.GetComponent<SA_SoundManager>().musicBack();
        yield return new WaitForSeconds(1);
        if(isSpinned > 0)
        {
            isSpinned = isSpinned - 1;
        }
        //hit = false;
        state = STAGE_STATE.SS_THINK;
        StopCoroutine("WasPlayerHurt");
    }
}
