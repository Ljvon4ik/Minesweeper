using CobeBase.Gameplay.Tiles;
using System.Collections.Generic;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class AdjacentTilesFinder
    {
        protected AdjacentTilesFinder() { }
        public static List<GameTile> GetAdjacentTiles(GameTile tile, TileMatrix matrix)
        {
            int width = matrix.GetRowsMatrixCount();
            int height = matrix.GetColumnsMatrixCount();
            int xPos = (int)tile.transform.position.x;
            int yPos = (int)tile.transform.position.y;

            List<GameTile> adjacentTiles = new();
            for (int x = xPos - 1; x <= xPos + 1; x++)
            {
                for (int y = yPos - 1; y <= yPos + 1; y++)
                {
                    if (x >= 0 && x < width && y >= 0 && y < height && !(x == xPos && y == yPos))
                        adjacentTiles.Add(matrix.GetTileMatrix()[x, y]);
                }
            }

            return adjacentTiles;
        }
    }
}
