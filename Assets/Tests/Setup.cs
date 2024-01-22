using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Board;
using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Factories;
using CobeBase.Gameplay.Tiles;
using CobeBase.Services.CurrentLevelProvider;
using NSubstitute;
using UnityEngine;

namespace Tests
{
    public class Setup
    {
        public static BoardGenerator BoardGenerator(LevelConfiguration levelConfiguration)
        {
            BoardGenerator boardGenerator = Create.BoardGenerator();
            GameTileContentFactory gameTileContentFactory = Create.ContentFactory();
            ICurrentLevelProvider currentLevelProvider = CurrentLevelProvider(levelConfiguration);
            boardGenerator.Construct(currentLevelProvider, gameTileContentFactory);
            return boardGenerator;
        }

        public static ICurrentLevelProvider CurrentLevelProvider(LevelConfiguration levelConfiguration)
        {
            ICurrentLevelProvider currentLevelProvider = Substitute.For<ICurrentLevelProvider>();
            currentLevelProvider.CurrentLevelConfiguration.Returns(levelConfiguration);
            return currentLevelProvider;
        }

        public static void SetTypeInAllTiles(TileMatrix matrix, GameTileType type)
        {
            for (int i = 0; i < matrix.GetRowsMatrixCount(); i++)
            {
                for (int j = 0; j < matrix.GetColumnsMatrixCount(); j++)
                {
                    GameTile tile = matrix.GetTileMatrix()[i, j];
                    tile.Type = type;
                }
            }
        }

        public static GameTile RandomGameTile(TileMatrix matrix)
        {
            int xPos = Random.Range(0, matrix.GetRowsMatrixCount());
            int yPos = Random.Range(0, matrix.GetColumnsMatrixCount());
            GameTile tile = matrix.GetTileMatrix()[xPos, yPos];
            return tile;
        }

        public static GameTile CentralGameTile(TileMatrix matrix)
        {
            int rows = matrix.GetRowsMatrixCount();
            int cols = matrix.GetColumnsMatrixCount();
            int centerRow = rows / 2;
            int centerCol = cols / 2;

            return matrix.GetTileMatrix()[centerRow, centerCol];
        }

        public static GameTile ZeroGameTile(TileMatrix matrix)
        {
            return matrix.GetTileMatrix()[0, 0];
        }

        public static void SetFalagIsTrueAllTiles(TileMatrix matrix)
        {
            foreach (GameTile tile in matrix.GetTileMatrix())
                tile.IsFlag = true;
        }

        public static GameTile GetAdjecentTile(GameTile tile, TileMatrix matrix)
        {
            int x = (int)tile.transform.position.x;
            int y = (int)tile.transform.position.y;

            GameTile right = matrix.GetTileMatrix()[x + 1, y];

            if(right == null)
            {
                GameTile left = matrix.GetTileMatrix()[x - 1, y];
                return left;
            }

            return right;
        }

    }
}
