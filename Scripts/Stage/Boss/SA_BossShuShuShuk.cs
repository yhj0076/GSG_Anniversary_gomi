using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_BossShuShuShuk : MonoBehaviour
{
    AudioSource soundPlayer;
    SpriteRenderer spriteRenderer;
    protected bool StageOn = false;
    protected float time = 0;
    public Vector2 destination;
    protected Vector2 beforePos;

    // Update is called once per frame
    public void Update()
    {
        if (StageOn)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, destination, 0.08f);
        }
        else
        {

            time += Time.deltaTime;
            if (time <= Mathf.PI / 2)
            {
                spriteRenderer.color = new Color(1, 1, 1, Mathf.Cos(time));
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 0);
                gameObject.SetActive(false);
            }
        }
    }
    private void OnEnable()
    {
        soundPlayer = GetComponent<AudioSource>();
        StageOn = true;
        beforePos = transform.localPosition;
        time = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 1);
        Invoke("Knives", 1.2f);
        switch (gameObject.name)
        {
            case "Jansang_BR":
                destination = new Vector2(7.28f, -3.42f);
                break;
            case "Jansang_BL":
                destination = new Vector2(-7.4f, -3.42f);
                break;
            case "Jansang_TR":
                destination = new Vector2(7.28f, 3.14f);
                break;
            case "Jansang_TL":
                destination = new Vector2(-7.4f, 3.14f);
                break;
        }
        Invoke("delay_StageOff", 1.2f);
        transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(4).GetChild(1).gameObject.SetActive(true);
        transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
        transform.GetChild(4).GetChild(3).gameObject.SetActive(true);
    }

    protected void delay_StageOff()
    {
        StageOn = false;
    }

    private void OnDisable()
    {
        transform.localPosition = beforePos;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(true);
        transform.parent.parent.GetComponent<SA_BossStageController>().state_obs = SA_BossStageController.BOSS_OBSTACLE.OBS_NONE;
        transform.parent.parent.GetComponent<SA_BossStageController>().knives = false;
    }

    void Knives()
    {
        soundPlayer.Play();
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(false);

    }
}
