using CobeBase.Gameplay.Tiles;

namespace CobeBase.Gameplay.Board
{
    public class TileMatrix
    {
        private readonly GameTile[,] _matrix;
        public TileMatrix(GameTile[,] matrix)
        {
            _matrix = matrix;
        }

        public GameTile[,] GetTileMatrix()
        { 
            return _matrix;
        }

        public int GetRowsMatrixCount()
        {
            return _matrix.GetLength(0);
        }

        public int GetColumnsMatrixCount()
        {
            return _matrix.GetLength(1);
        }
    }
}
