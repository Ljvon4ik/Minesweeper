using UnityEngine;

namespace CobeBase.CameraLogic
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(CameraMoveController))]
    [RequireComponent(typeof(CameraZoomController))]

    public class CameraController : MonoBehaviour
    {
        private readonly float _offset = 0.5f; //tile center

        public void Init(float width, float height)
        {
            CameraMoveController moveController = GetComponent<CameraMoveController>();
            moveController.Init(GetCenter(width, height));

            CameraZoomController zoomController = GetComponent<CameraZoomController>();
            zoomController.Init(GetStartSize(width));
        }

        private float GetStartSize(float width)
        {
            float size = width * Screen.height / Screen.width * 0.5f;
            return size;
        }

        private Vector3 GetCenter(float width, float height)
        {
            float centerX = width / 2 - _offset;
            float centerY = height / 2 - _offset;
            Vector3 center = new(centerX, centerY, transform.position.z);
            return center;
        }
    }
}
