using CobeBase.Gameplay.Tiles;
using CodeBase.Input;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace CobeBase.Services.InputServices
{
    public class MouseInput : IInputService, IDisposable
    {
        private readonly MyNewInput _input;
        public event Action<GameTile> TileClicked;
        public event Action<GameTile> TileHeld;
        public event Action<GameTile> TileDoubleClicked;

        public MouseInput(MyNewInput input)
        {
            _input = input;
            _input.Enable();
            _input.Player.OneClick.performed += Click;
            _input.Player.Hold.performed += Hold;
            _input.Player.DoubleClick.performed += DoubleClick;
        }

        private void DoubleClick(CallbackContext context)
        {
            GameTile tile = GetTile();
            if (tile != null)
                TileDoubleClicked?.Invoke(tile);
        }


        private void Hold(CallbackContext context)
        {
            GameTile tile = GetTile();
            if (tile != null)
                TileHeld?.Invoke(tile);
        }

        private void Click(CallbackContext context)
        {
            GameTile tile = GetTile();
            if (tile != null)
                TileClicked?.Invoke(GetTile());
        }

        private GameTile GetTile()
        {
            var hit = Raycast();

            if (hit == null)
                return null;

            if (hit.Value.collider == null)
                return null;

            if (hit.Value.collider.TryGetComponent<GameTile>(out GameTile tile))
                return tile;

            return null;
        }

        private RaycastHit2D? Raycast()
        {
            var isOverUI = EventSystem.current.IsPointerOverGameObject();
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector2 worldpos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(worldpos, Vector2.zero);
            if (!isOverUI)
                return hit;
            return null;
        }

        public void Dispose()
        {
            _input.Player.OneClick.performed -= Click;
            _input.Player.Hold.performed -= Click;
            _input.Player.DoubleClick.performed -= DoubleClick;
            _input.Disable();
        }
    }
}
