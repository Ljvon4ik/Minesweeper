using UnityEngine;

namespace CobeBase.CameraLogic
{
    [RequireComponent(typeof(Camera))]
    public class CameraZoomController : MonoBehaviour
    {
        public void Init(float startSize)
        {
            Camera camera = GetComponent<Camera>();
            camera.orthographicSize = startSize;
        }
    }
}
