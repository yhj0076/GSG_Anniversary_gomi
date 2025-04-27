using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SA_BossHealth : MonoBehaviour
{
    public GameObject healthHeart;
    public GameObject HEART;
    public int hp;
    public AudioClip hurt;

    public enum BOSSHEALTH_STATE
    {
        BS_NONE,
        BS_POWWWER,
        BS_DIE
    }

    public BOSSHEALTH_STATE state
    {
        get;
        private set;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        hp = 10;
        healthCheck(hp);
    }

    public void healthCheck(int HP)  // 플레이어의 체력
    {
        if (HP > healthHeart.transform.childCount)
        {
            int dif = HP - healthHeart.transform.childCount;
            for (int i = 0; i < dif; i++)
            {
                var heart = GameObject.Instantiate(HEART, Vector2.zero, Quaternion.identity);
                heart.transform.localPosition = healthHeart.transform.localPosition + new Vector3(0 - 0.8f * (healthHeart.transform.childCount), 0, 0);
                heart.transform.parent = healthHeart.transform;
            }
        }
        else if (HP < healthHeart.transform.childCount)
        {
            int dif = healthHeart.transform.childCount - HP;
            for (int i = 0; i < dif; i++)
            {
                Destroy(healthHeart.transform.GetChild(healthHeart.transform.childCount - 1).gameObject);
            }
        }
    }

    public void Hurt()
    {
        if (state == BOSSHEALTH_STATE.BS_NONE)
        {
            hp -= 1;
            Debug.Log("보스 남은 체력 : " + hp);
            GetComponent<AudioSource>().PlayOneShot(hurt);
            healthCheck(hp);
            StartCoroutine("hurtEffect");
            if(hp <= 5)
            {
                transform.GetChild(6).GetComponent<Animator>().SetBool("Phase2",true);
                transform.GetChild(7).GetComponent<Animator>().SetBool("Phase2",true);
            }
            else
            {
                transform.GetChild(6).GetComponent<Animator>().SetBool("Phase2", false);
                transform.GetChild(7).GetComponent<Animator>().SetBool("Phase2", false);
            }


            if (hp <= 0)
            {
                transform.parent.GetComponent<SA_BossStageController>().state = SA_BossStageController.BOSS_STATE.BOSS_DEFEAT;
                int i = transform.childCount;
                for (int j = 0; j < i; j++)
                {
                    if (transform.GetChild(j).gameObject.activeSelf)
                    {
                        transform.GetChild(j).gameObject.SetActive(false);
                    }
                }
                transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            }
            state = BOSSHEALTH_STATE.BS_POWWWER;
        }
    }

    IEnumerator hurtEffect()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(1,0,0,1f);
        transform.GetComponent<Animator>().SetTrigger("dmg");
        yield return new WaitForSeconds(0.1f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1f);
        transform.GetComponent<Animator>().ResetTrigger("dmg");
        state = BOSSHEALTH_STATE.BS_NONE;
    }
}
