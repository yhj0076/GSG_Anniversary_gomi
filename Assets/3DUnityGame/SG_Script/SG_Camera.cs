using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_Camera : MonoBehaviour
{
    public Transform PlayerCamera;
    public Transform CameraRoot;
    public float mouseX;
    public float mouseY;
    public float rotY;
    public float rotX;
    public float inputSensitivity = 150.0f;
    float clampAngle = 40;
    float YclampAngle = 150;
    public bool canmovecamera;
    public static SG_Camera sgcamera;
    
    //Camera FadeIn, FadeOut//
    public float speedSclae = 1.0f;
    public Color fadeColor = Color.black;
    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool startFadeOut = false;
    private float alpha = 0;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0;
    Vector3 CameraRootRot = new Vector3(15, 90, 0);
 //   private bool isfading = false;
    // Start is called before the first frame update
    private void Awake()
    {
        sgcamera = this;
    }
    void Start()
    {
       // canmovecamera = true;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.x;
        rotX = rot.y;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if(canmovecamera)
            CameraMovement();

    }
    void CameraMovement()
    {
        mouseY = -Input.GetAxis("Mouse Y");
        mouseX = Input.GetAxis("Mouse X");

        rotY += mouseX * inputSensitivity * Time.deltaTime;
        rotX += mouseY * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle , clampAngle );
        rotY = Mathf.Clamp(rotY, -YclampAngle, YclampAngle);
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.localRotation = localRotation;
    }
   
    public void OnGUI()
    {

        if (alpha > 0)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedSclae;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0 || alpha >= 1)
                direction = 0;
        }

    }

    public void FadingOut()
    {
        if (direction == 0)
        {
            alpha = 1;
            time = 0;
            direction = 1;
        }
    }
    public void FadingIn()
    {
        if (direction == 0)
        {
            alpha = 0;
            time = 1;
        }
    }
    public void SetUpCameraRootRotation()
    {
        CameraRoot.rotation = Quaternion.Euler(CameraRootRot);
    }
}
