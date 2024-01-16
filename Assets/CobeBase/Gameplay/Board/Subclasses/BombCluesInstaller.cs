using CobeBase.Gameplay.Tiles;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class BombCluesInstaller : InitializableBaseSubclass
    {
        private AdjacentTilesFinder _adjacentTilesFinder;

        public BombCluesInstaller(AdjacentTilesFinder adjacentTilesFinder, BoardGenerator boardGenerator)
            : base(boardGenerator)
        {
            _adjacentTilesFinder = adjacentTilesFinder;
        }


        public void SetBombClues()
        {
            ArrayOfTiles = _boardGenerator.ArrayOfTiles;

            GameTileType bombType = GameTileType.Bomb;

            foreach (GameTile tile in ArrayOfTiles)
            {
                if (tile.Type == bombType)
                    continue;

                byte adjacentBombs = 0;

                foreach (GameTile adjacentTile in _adjacentTilesFinder.GetAdjacentTiles(tile))
                {
                    if (adjacentTile.Type == bombType)
                        adjacentBombs++;
                }

                if (adjacentBombs > 0)
                    tile.AdjacentBombCount = adjacentBombs;
            }
        }
    }
}
