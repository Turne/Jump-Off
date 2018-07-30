using UnityEngine;

namespace MyGame
{
    class GameCamera : MonoBehaviour
    {
        float devHeight = 12.8f;
        float devWidth = 8.0f;

        // Use this for initialization
        void Start()
        {

            float screenHeight = Screen.height;

            Debug.Log("screenHeight = " + screenHeight);

            float orthographicSize = this.GetComponent<Camera>().orthographicSize;

            float aspectRatio = Screen.width * 1.0f / Screen.height;

            float cameraWidth = orthographicSize * 2 * aspectRatio;

            Debug.Log("cameraWidth = " + cameraWidth);

            orthographicSize = devWidth / (2 * aspectRatio);
            Debug.Log("new orthographicSize = " + orthographicSize);
            this.GetComponent<Camera>().orthographicSize = orthographicSize;

        }
    }
}
