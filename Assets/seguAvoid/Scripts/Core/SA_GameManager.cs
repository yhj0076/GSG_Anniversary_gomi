using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SA_GameManager : MonoBehaviour
{
    public static SA_GameManager instance;
    Scene scene;

    void Awake()
    {
        SecurityPlayerPrefs.SetInt("SA_Finish", 0);
        if (instance == null)
        {
            instance = this;
            if (SecurityPlayerPrefs.GetInt("SA_Finish", 0) == 1)
            {
                SceneManager.LoadScene(4);
            }
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }

        if(SecurityPlayerPrefs.GetInt("FirstGame",-1) == -1)
        {
            SecurityPlayerPrefs.SetInt("FirstGame",1);
            SecurityPlayerPrefs.SetInt("BestScore",0);
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene(4);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    public void Clear()
    {
        SceneManager.LoadScene(4);
    }

    public void StoryStart()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSceneWithNum(int Num)
    {
        SceneManager.LoadScene(Num);
    }

    public void _ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void gotoEnding()
    {
        SceneManager.LoadScene(7);
    }
}
