using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Tiles;


namespace CobeBase.Gameplay.Board
{
    public class GameBoard
    {
        private BoardGenerator _boardGenerator;
        private BombInstaller _bombInstaller;
        private BombCluesInstaller _bombCluesInstaller;
        private Filler _filler;

        public GameBoard (BoardGenerator boardGenerator, BombInstaller bombTilesInitializer,
            BombCluesInstaller bombIndicatorTilesInitializer, Filler filler)
        {
            _boardGenerator = boardGenerator;
            _bombInstaller = bombTilesInitializer;
            _bombCluesInstaller = bombIndicatorTilesInitializer;
            _filler = filler;
        }

        public void GenerateBoard()
        {
            _boardGenerator.GenerateBoard();
        }


        public void PlaceBombs(GameTile tile)
        {
            _bombInstaller.PlaceBombs(tile);
        }

        public void PlaceClues()
        {
            _bombCluesInstaller.SetBombClues();
        }

        public void OpenAdjacentEmptyTiles(GameTile tile)
        {
            _filler.FloodFill(tile);
        }
    }
}
