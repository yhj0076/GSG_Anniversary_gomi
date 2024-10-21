using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_BossEldenRing : MonoBehaviour
{
    float time = 0;

    bool Danger1;
    bool Danger2;
    bool Axe1;
    bool Axe2;
    private void OnEnable()
    {
        time = 0;
        Danger1 = false;
        Danger2 = false;
        Axe1 = false;
        Axe2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 0.75f && Danger1 == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Danger1 = true;
        }
        else if (time > 1.5f && Axe1 == false)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            Axe1 = true;
        }
        else if (time > 2.25f && Danger2 == false)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            Danger2 = true;
        }
        else if (time > 3f && Axe2 == false)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            Axe2 = true;
        }


        if (Axe2 && transform.GetChild(3).gameObject.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        transform.parent.parent.GetComponent<SA_BossStageController>().Ring_time = 0;
        transform.parent.parent.GetComponent<SA_BossStageController>().state_obs = SA_BossStageController.BOSS_OBSTACLE.OBS_NONE;
    }
}
