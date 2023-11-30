using UnityEngine;

namespace CobeBase.CameraLogic
{
    [RequireComponent(typeof(Camera))]
    public class CameraZoomController : MonoBehaviour
    {
        private Camera _camera;

        public void Init(float startSize)
        {
            _camera = GetComponent<Camera>();
            _camera.orthographicSize = startSize;
        }
    }
}
