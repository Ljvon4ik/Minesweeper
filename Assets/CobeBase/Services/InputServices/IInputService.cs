using CobeBase.Gameplay.Tiles;
using System;

namespace CobeBase.Services.InputServices
{
    public interface IInputService
    {
        public event Action<GameTile> TileClicked;
        public event Action<GameTile> TileHeld;
        public event Action<GameTile> TileDoubleClicked;

    }
}