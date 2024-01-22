using CobeBase.Gameplay.Tiles;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class TileFlagManager
    {
        public void ChangeValue(GameTile tile)
        {
            if(tile.IsFlag)
                tile.IsFlag = false;
            else
                tile.IsFlag = true;
        }
    }
}
