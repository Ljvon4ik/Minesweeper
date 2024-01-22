using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Tiles;

namespace CobeBase.Gameplay.Board
{
    public class Filler : InitializableBaseSubclass
    {
        public Filler(BoardGenerator boardGenerator)
            : base(boardGenerator) { }

        public void FloodFill(GameTile tile)
        {
            if (tile.IsOpened || tile.Type == GameTileType.Bomb)
                return;

            tile.IsOpened = true;

            if (tile.Type == GameTileType.Empty)
            {                
                foreach (GameTile adjacentTiles in AdjacentTilesFinder.GetAdjacentTiles(tile, _boardGenerator.TileMatrix))
                    if (!adjacentTiles.IsOpened)
                        FloodFill(adjacentTiles);
            }
        }
    }
}
