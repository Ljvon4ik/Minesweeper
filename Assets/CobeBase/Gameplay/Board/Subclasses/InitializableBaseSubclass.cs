using CobeBase.Gameplay.Tiles;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class InitializableBaseSubclass
    {
        protected BoardGenerator _boardGenerator;

        public InitializableBaseSubclass(BoardGenerator boardGenerator)
        {
            _boardGenerator = boardGenerator;
        }
    }
}