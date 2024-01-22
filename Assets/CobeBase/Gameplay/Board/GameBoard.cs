using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Tiles;


namespace CobeBase.Gameplay.Board
{
    public class GameBoard
    {
        private readonly BoardGenerator _boardGenerator;
        private readonly BombInstaller _bombInstaller;
        private readonly BombCluesInstaller _bombCluesInstaller;
        private readonly Filler _filler;
        private readonly TileFlagManager _flagManager;
        private readonly AutoDigger _digger;

        public GameBoard (BoardGenerator boardGenerator, BombInstaller bombTilesInitializer,
            BombCluesInstaller bombIndicatorTilesInitializer, Filler filler,
            TileFlagManager flagManager, AutoDigger digger)
        {
            _boardGenerator = boardGenerator;
            _bombInstaller = bombTilesInitializer;
            _bombCluesInstaller = bombIndicatorTilesInitializer;
            _filler = filler;
            _flagManager = flagManager;
            _digger = digger;
        }

        public void GenerateBoard()
        {
            _boardGenerator.GenerateBoard();
        }


        public void PlaceBombs(GameTile tile)
        {
            _bombInstaller.PlaceBombs(tile);
            _bombCluesInstaller.SetBombClues();
        }

        public void OpenAdjacentEmptyTiles(GameTile tile)
        {
            _filler.FloodFill(tile);
        }

        public void FlagTile(GameTile tile)
        {
            _flagManager.ChangeValue(tile);
        }

        public void EasyDigging(GameTile tile)
        {
            _digger.EasyDig(tile);
        }
    }
}
