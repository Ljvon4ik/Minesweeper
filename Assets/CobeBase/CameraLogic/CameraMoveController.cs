using UnityEngine;

namespace CobeBase.CameraLogic
{
    public class CameraMoveController : MonoBehaviour
    {
        [Range(1f, 10f)]
        [SerializeField]
        private float _speed;

        private Vector3 _center;

        public void Init(Vector3 center)
        {
            _center = center;
            transform.position = _center;
        }

        private void LateUpdate()
        {
            if (!IsCenter())
                MoveToCenter();
        }


        private bool IsCenter()
        {
            float difference = Mathf.Abs(transform.position.sqrMagnitude - _center.sqrMagnitude);
            bool isCenter = difference < 0.01f;
            return isCenter;
        }
        private void MoveToCenter()
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position, _center, _speed * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
