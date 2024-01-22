using CobeBase.Gameplay.Tiles;
using CobeBase.Services.InputServices;
using System;

namespace CobeBase.Gameplay.Board
{
    public class BoardInputHandler : IDisposable
    {
        private readonly GameBoard _gameBoard;
        private bool _isFirstTileOpen;
        private readonly IInputService _input;

        public BoardInputHandler(IInputService input, GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            _input = input;
            _input.TileClicked += TileCliked;
            _input.TileHeld += TileHeld;
            _input.TileDoubleClicked += TileDoubleClicked;
        }

        private void TileDoubleClicked(GameTile tile)
        {
            _gameBoard.EasyDigging(tile);
        }

        private void TileHeld(GameTile tile)
        {
            if (tile.IsOpened)
                return;

            if (!_isFirstTileOpen)
                return;

            if (!tile.IsOpened)
                _gameBoard.FlagTile(tile);
        }

        private void TileCliked(GameTile tile)
        {
            if (tile.IsOpened)
                return;

            if (!_isFirstTileOpen)
            {
                _gameBoard.PlaceBombs(tile);
                _isFirstTileOpen = true;
            }

            if (tile.Type == GameTileType.Empty)
            {
                _gameBoard.OpenAdjacentEmptyTiles(tile);
                return;
            }

            tile.IsOpened = true;
        }

        public void Dispose()
        {
            _input.TileClicked -= TileCliked;
            _input.TileHeld -= TileHeld;
            _input.TileDoubleClicked -= TileDoubleClicked;
        }
    }
}
