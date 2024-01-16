using CobeBase.Data.StaticData;
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

        public static void SetTypeInAllTiles(GameTile[,] arrayOfTiles, GameTileType type)
        {
            for (int i = 0; i < arrayOfTiles.GetLength(0); i++)
            {
                for (int j = 0; j < arrayOfTiles.GetLength(1); j++)
                {
                    GameTile tile = arrayOfTiles[i, j];
                    tile.Type = type;
                }
            }
        }

        public static GameTile RandomGameTile(GameTile[,] arrayOfTiles)
        {
            int xPos = Random.Range(0, arrayOfTiles.GetLength(0));
            int yPos = Random.Range(0, arrayOfTiles.GetLength(1));
            GameTile tile = arrayOfTiles[xPos, yPos];
            return tile;
        }

        public static GameTile CentralGameTile(GameTile[,] arrayOfTiles)
        {
            int rows = arrayOfTiles.GetLength(0);
            int cols = arrayOfTiles.GetLength(1);
            int centerRow = rows / 2;
            int centerCol = cols / 2;

            return arrayOfTiles[centerRow, centerCol];
        }

        public static GameTile ZeroGameTile(GameTile[,] arrayOfTiles)
        {
            return arrayOfTiles[0, 0];
        }
    }
}
