using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_GliderFace : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMesh;
    float ShapeSpeed = 600f;
    public static SG_GliderFace gliderface;
    // Start is called before the first frame update
    private void Awake()
    {
        gliderface = this;
    }
    void Start()
    {
        //skinnedMesh = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeFace(int dir, int which)
    {
        float temp_ttear = skinnedMesh.GetBlendShapeWeight(dir);
        float temp = skinnedMesh.GetBlendShapeWeight(3);
        float temp_Tear = temp_ttear - Time.deltaTime * ShapeSpeed;
        float temp_else = temp + Time.deltaTime * ShapeSpeed;
        temp_Tear = Mathf.Clamp(temp_Tear, 0, 100);
        temp_else = Mathf.Clamp(temp_else, 0, 100);
        skinnedMesh.SetBlendShapeWeight(dir, temp_Tear);
        skinnedMesh.SetBlendShapeWeight(which, temp_else);
        skinnedMesh.SetBlendShapeWeight(3, temp_else);
        skinnedMesh.SetBlendShapeWeight(4, temp_else);
        skinnedMesh.SetBlendShapeWeight(8, temp_else);
    }
    public void ReturnFace(int dir, int which)
    {
        float temp_ttear = skinnedMesh.GetBlendShapeWeight(dir);
        float temp = skinnedMesh.GetBlendShapeWeight(3);
        float temp_Tear = temp_ttear + Time.deltaTime * ShapeSpeed;
        float temp_else = temp - Time.deltaTime * ShapeSpeed;
        temp_Tear = Mathf.Clamp(temp_Tear, 0, 100);
        temp_else = Mathf.Clamp(temp_else, 0, 100);
        skinnedMesh.SetBlendShapeWeight(dir, temp_Tear);
        skinnedMesh.SetBlendShapeWeight(which, temp_else);
        skinnedMesh.SetBlendShapeWeight(3, temp_else);
        skinnedMesh.SetBlendShapeWeight(4, temp_else);
        skinnedMesh.SetBlendShapeWeight(8, temp_else);
    }

}
