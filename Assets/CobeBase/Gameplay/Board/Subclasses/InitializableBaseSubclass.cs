using CobeBase.Gameplay.Tiles;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class InitializableBaseSubclass
    {
        protected GameTile[,] ArrayOfTiles { get; set; }
        protected BoardGenerator _boardGenerator;

        public InitializableBaseSubclass(BoardGenerator boardGenerator)
        {
            _boardGenerator = boardGenerator;
        }
    }
}