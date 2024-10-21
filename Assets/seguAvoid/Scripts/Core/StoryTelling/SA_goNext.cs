using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SA_goNext : MonoBehaviour
{
    public Image Fade;

    float time = 0;
    bool cont = false;
    // Start is called before the first frame update
    void Start()
    {
        Fade.color = new Color(0, 0, 0, 1);
        time = Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
        Fade.color = new Color(0,0,0,Mathf.Sin(time)+1);
        if(time<Mathf.PI*3/2||cont)
        {
            time += Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            cont = true;
        }

        if(time>Mathf.PI*2)
        {
            SceneManager.LoadScene(2);
        }
    }
}
