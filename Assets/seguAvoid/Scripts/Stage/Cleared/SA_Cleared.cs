using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Cleared : MonoBehaviour
{
    public GameObject player;
    public GameObject Wall;
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > 9.48)
        {
            gameObject.SetActive(false);
        }
        else
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0),ForceMode2D.Impulse);
        }
    }

    private void OnEnable()
    {
        Wall.SetActive(false);
        //player.GetComponent<Rigidbody2D>().velocity = new Vector2(7,0);
        player.GetComponent<SA_PlayerController>().cleared = true;
        player.GetComponent<SA_SeguAnime>().isRight();
        player.GetComponent<SA_SeguAnime>().conditionIndex(1);
        if (player.GetComponent<SA_PlayerController>().Zhonya)
        {
            player.GetComponent<SA_PlayerController>().ZhonyaFalse();
        }
    }

    private void OnDisable()
    {
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
