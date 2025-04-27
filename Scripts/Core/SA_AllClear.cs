using UnityEngine;

public class SA_AllClear : MonoBehaviour
{
    
    // SecurityPlayerPrefs 초기화하는 코드. 주의 요망.

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl)&&Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.G))
        {
            SecurityPlayerPrefs.DeleteAll();
        }
    }
}
