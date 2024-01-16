using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Tiles;
using CobeBase.Services.CurrentLevelProvider;
using System.Collections.Generic;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class AdjacentTilesFinder : InitializableBaseSubclass
    {
        private readonly int _width;
        private readonly int _height;

        public AdjacentTilesFinder(ICurrentLevelProvider currentLevelProvider, BoardGenerator boardGenerator)
            : base(boardGenerator)
        {
            LevelConfiguration configuration = currentLevelProvider.CurrentLevelConfiguration;
            _width = configuration.WidthBoard;
            _height = configuration.HeightBoard;
        }

        public List<GameTile> GetAdjacentTiles(GameTile tile)
        {
            ArrayOfTiles = _boardGenerator.ArrayOfTiles;

            int xPos = (int)tile.transform.position.x;
            int yPos = (int)tile.transform.position.y;

            List<GameTile> adjacentTiles = new();
            for (int x = xPos - 1; x <= xPos + 1; x++)
            {
                for (int y = yPos - 1; y <= yPos + 1; y++)
                {
                    if (x >= 0 && x < _width && y >= 0 && y < _height && !(x == xPos && y == yPos))
                        adjacentTiles.Add(ArrayOfTiles[x, y]);
                }
            }

            return adjacentTiles;
        }
    }
}
