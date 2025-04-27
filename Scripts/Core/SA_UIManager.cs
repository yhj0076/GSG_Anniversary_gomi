using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SA_UIManager : MonoBehaviour
{
    public static SA_UIManager instance;
    public GameObject healthHeart;
    public GameObject HEART;
    public Text scoreText;

    public Sprite empty;
    public Sprite full;

    int MaxHealth;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            MaxHealth = FindObjectOfType<SA_HealthController>().Maxhealth;
            
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 UI 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < FindObjectOfType<SA_HealthController>().health; i++)
        {
            var heart = GameObject.Instantiate(HEART, transform.localPosition + new Vector3(0 + 0.8f * i, 0, 0), Quaternion.identity);
            heart.transform.localPosition = healthHeart.transform.localPosition + new Vector3(0 + 0.8f * i, 0, 0);
            heart.transform.parent = healthHeart.transform;
        }
    }


    public void healthCheck(int HP)  // 플레이어의 체력
    {
        if (HP > healthHeart.transform.childCount)
        {
            int dif = HP - healthHeart.transform.childCount;
            for (int i = 0; i< dif; i++)
            {
                var heart = GameObject.Instantiate(HEART, Vector2.zero, Quaternion.identity);
                heart.transform.localPosition = healthHeart.transform.localPosition + new Vector3(0 + 0.8f * (healthHeart.transform.childCount), 0, 0);
                heart.transform.parent = healthHeart.transform;
            }
        }
        else if(HP < healthHeart.transform.childCount)
        {
            int dif = healthHeart.transform.childCount - HP;
            for (int i = 0; i < dif; i++)
            {
                Destroy(healthHeart.transform.GetChild(healthHeart.transform.childCount - 1).gameObject);
            }
        }
        else{

        }
    }

    public void Score(int score)
    {
        if (score > 10)
        {
            scoreText.text = "??/10";
            scoreText.GetComponent<Outline>().effectColor = Color.red;
        }
        else
        {
            scoreText.text = score + "/10";
        }
    }
}
