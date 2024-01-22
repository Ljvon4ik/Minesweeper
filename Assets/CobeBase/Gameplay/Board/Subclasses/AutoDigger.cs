using CobeBase.Gameplay.Tiles;
using System.Diagnostics;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class AutoDigger : InitializableBaseSubclass
    {
        private readonly Filler _filler;
        public AutoDigger(BoardGenerator boardGenerator, Filler filler)
            : base(boardGenerator) 
        {
            _filler = filler;
        }

        public void EasyDig(GameTile tile)
        {
            int bombs = tile.AdjacentBombCount;
            int flags = 0;


            foreach (GameTile adjacentTile in AdjacentTilesFinder.GetAdjacentTiles(tile, _boardGenerator.TileMatrix))
            {
                if (adjacentTile.IsFlag)
                    flags++;
            }

            if (bombs != flags)
                return;

            foreach (GameTile adjacentTile in AdjacentTilesFinder.GetAdjacentTiles(tile, _boardGenerator.TileMatrix))
            {
                if (adjacentTile.IsFlag)
                    continue;

                if (adjacentTile.IsOpened)
                    continue;

                if (adjacentTile.Type == GameTileType.Empty)
                {
                    _filler.FloodFill(adjacentTile);
                    continue;
                }

                adjacentTile.IsOpened = true;
            }
        }
    }
}
