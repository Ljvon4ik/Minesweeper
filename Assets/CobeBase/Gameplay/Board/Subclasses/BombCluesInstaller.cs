using CobeBase.Gameplay.Tiles;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class BombCluesInstaller : InitializableBaseSubclass
    {
        public BombCluesInstaller(BoardGenerator boardGenerator)
            : base(boardGenerator) { }

        public void SetBombClues()
        {
            GameTileType bombType = GameTileType.Bomb;

            foreach (GameTile tile in _boardGenerator.TileMatrix.GetTileMatrix())
            {
                if (tile.Type == bombType)
                    continue;

                byte adjacentBombs = 0;

                foreach (GameTile adjacentTile in AdjacentTilesFinder.GetAdjacentTiles(tile, _boardGenerator.TileMatrix))
                {
                    if (adjacentTile.Type == bombType)
                        adjacentBombs++;
                }

                tile.AdjacentBombCount = adjacentBombs;
            }
        }
    }
}
