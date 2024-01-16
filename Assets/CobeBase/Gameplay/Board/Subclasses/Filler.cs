using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Tiles;

namespace CobeBase.Gameplay.Board
{
    public class Filler
    {
        private AdjacentTilesFinder _adjacentTilesFinder;

        public Filler(AdjacentTilesFinder adjacentTilesFinder)
        {
            _adjacentTilesFinder = adjacentTilesFinder;
        }

        public void FloodFill(GameTile tile)
        {
            if (tile.IsOpened || tile.Type == GameTileType.Bomb)
                return;

            tile.IsOpened = true;

            if (tile.Type == GameTileType.Empty)
            {                
                foreach (GameTile adjacentTiles in _adjacentTilesFinder.GetAdjacentTiles(tile))
                    FloodFill(adjacentTiles);
            }
        }
    }
}
