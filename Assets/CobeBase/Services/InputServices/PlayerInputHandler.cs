using CobeBase.Gameplay.Tiles;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CobeBase.Services.InputServices
{
    public class PlayerInputHandler : IInputService, ITickable
    {
        private readonly Camera _camera;
        public event Action<GameTile> TileClicked;
        
        public PlayerInputHandler(Camera camera)
        {
            _camera = camera;
        }

        public void Tick()
        {
            if (IsPointerDown() == false)
                return;

            var hit = Raycast();
            if (hit == null)
                return;

            if (hit.Value.collider == null)
                return;

            if (hit.Value.collider.TryGetComponent<GameTile>(out GameTile gameTile))
                TileClicked?.Invoke(gameTile);
        }

        public bool IsPointerDown()
        {
#if UNITY_EDITOR
            return Input.GetMouseButtonDown(0);
#else
            return Input.touches.Length == 1 && Input.touches[0].phase == TouchPhase.Began;
#endif
        }

        private RaycastHit2D? Raycast()
        {
            var isOverUI = EventSystem.current.IsPointerOverGameObject();
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (isOverUI == false)
                return hit;
            return null;
        }
    }
}
