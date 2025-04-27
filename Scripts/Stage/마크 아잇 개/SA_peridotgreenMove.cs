using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_peridotgreenMove : MonoBehaviour
{
    public Vector2 p1;
    public Vector2 p2;
    public Vector2 p3;
    public Vector2 p4;

    float time = 0;
    public float moveTime;
    // Start is called before the first frame update
    void OnEnable()
    {
        time = 0;
        transform.position = new Vector2(1.85f,-6.44f);
    }

    private void OnDisable()
    {
        transform.position = new Vector2(1.85f, -6.44f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 4.5f)
        {
            transform.position = Bezier(p1, p2, p3, p4, (time - 4.5f) / moveTime);
        }
    }

    public Vector2 Bezier(Vector2 p_1, Vector2 p_2, Vector2 p_3, Vector2 p_4, float value)   // value : 0 ~ 1의 float 값
    {
        Vector2 a = Vector2.Lerp(p_1, p_2, value);
        Vector2 b = Vector2.Lerp(p_2, p_3, value);
        Vector2 c = Vector2.Lerp(p_3, p_4, value);

        Vector2 d = Vector2.Lerp(a, b, value);
        Vector2 e = Vector2.Lerp(b, c, value);

        Vector2 f = Vector2.Lerp(d, e, value);

        return f;
    }
}
