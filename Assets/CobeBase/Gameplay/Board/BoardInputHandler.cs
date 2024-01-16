using CobeBase.Gameplay.Tiles;
using CobeBase.Services.InputServices;

namespace CobeBase.Gameplay.Board
{
    public class BoardInputHandler
    {
        private readonly IInputService _inputService;
        private readonly GameBoard _gameBoard;
        private bool _isFirstTileOpen;

        public BoardInputHandler(IInputService inputService, GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            _inputService = inputService;
            _inputService.TileClicked += TileCliked;
        }

        private void TileCliked(GameTile tile)
        {
            if (tile.IsOpened)
                return;

            if (!_isFirstTileOpen)
            {
                _gameBoard.PlaceBombs(tile);
                _gameBoard.PlaceClues();
                _isFirstTileOpen = true;
            }

            if (tile.Type == GameTileType.Empty)
            {
                _gameBoard.OpenAdjacentEmptyTiles(tile);
                return;
            }

            tile.IsOpened = true;
        }

        ~BoardInputHandler()
        {
            _inputService.TileClicked -= TileCliked;
        }
    }
}
