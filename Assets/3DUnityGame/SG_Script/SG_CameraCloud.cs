using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Clouds
{
    public class SG_CameraCloud : MonoBehaviour
    {

        public static SG_CameraCloud cameracloud;
        // Start is called before the first frame update
        private void Awake()
        {
            cameracloud = this;
        }
        public void CameraCloudOn()
        {
            gameObject.GetComponent<Clouds>().enabled = true;
        }
    }
}