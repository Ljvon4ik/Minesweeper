using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Board;
using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Tiles;
using NUnit.Framework;

namespace Tests
{
    public class BoardTests
    {
        [Test]
        public void WhenBoardGenerating_AndArrayOfTilesIsEmpty_ThenArrayOfTilesLengthIsEqualToHeightBoardMultipliedByWidthBoard()
        {
            // Arrange
            LevelConfiguration levelConfiguration = Create.LevelConfiguration();
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            int arrayLenght = levelConfiguration.WidthBoard * levelConfiguration.HeightBoard;

            // Act
            boardGenerator.GenerateBoard();

            // Assert
            Assert.That(boardGenerator.ArrayOfTiles, Has.Length.EqualTo(arrayLenght));
        }


        [Test]
        public void WhenBombsPlacing_AndGenerateBoard_ThenBombTilesTypeCountIsEqualToLevelsConfigBombsCount()
        {
            // Arrange
            const GameTileType bombType = GameTileType.Bomb;
            LevelConfiguration levelConfiguration = Create.LevelConfiguration();
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            BombInstaller bombInstaller = Create.BombInstaller(boardGenerator, levelConfiguration);
            boardGenerator.GenerateBoard();
            GameTile firstClickedTile = Setup.RandomGameTile(boardGenerator.ArrayOfTiles);

            // Act
            bombInstaller.PlaceBombs(firstClickedTile);

            // Assert
            byte bombsCountLevel = 0;
            for (int i = 0; i < boardGenerator.ArrayOfTiles.GetLength(0); i++)
            {
                for (int j = 0; j < boardGenerator.ArrayOfTiles.GetLength(1); j++)
                {
                    GameTile tile = boardGenerator.ArrayOfTiles[i, j];
                    if (tile.Type == bombType)
                    {
                        bombsCountLevel++;
                    }
                }
            }

            byte bombsCountLevelConfig = levelConfiguration.BombsCount;

            Assert.AreEqual(bombsCountLevel, bombsCountLevelConfig);
        }


        [Test]
        public void WhenCluesPlacing_AndBombsPlaced_ThenEachBombHasCluesInAdjacentTiles()
        {
            // Arrange
            LevelConfiguration levelConfiguration = Create.LevelConfiguration();
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            BombInstaller bombInstaller = Create.BombInstaller(boardGenerator, levelConfiguration);
            BombCluesInstaller bombCluesInstaller = Create.BombCluesInstaller(boardGenerator, levelConfiguration);
            boardGenerator.GenerateBoard();
            GameTile firstClickedTile = Setup.RandomGameTile(boardGenerator.ArrayOfTiles);
            bombInstaller.PlaceBombs(firstClickedTile);

            // Act
            bombCluesInstaller.SetBombClues();

            // Assert
            Assert.That(DoesEachBombHaveClues(boardGenerator, levelConfiguration));
        }


        [Test]
        public void WhenFloodFilling_AndAdjacentTilesAreEmpty_ThenAdjacentTilesAreOpened()
        {
            // Arrange
            LevelConfiguration levelConfiguration = Create.SpecialLevelConfiguration(0, 4, 4);
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            boardGenerator.GenerateBoard();
            Filler filler = Create.Filler(boardGenerator, levelConfiguration);
            Setup.SetTypeInAllTiles(boardGenerator.ArrayOfTiles, GameTileType.Empty);
            GameTile openableTile = Setup.CentralGameTile(boardGenerator.ArrayOfTiles);

            // Act
            filler.FloodFill(openableTile);

            // Assert
            Assert.That(AreAllTilesOpen(boardGenerator));
        }


        [Test]
        public void WhenFloodFilling_AndAdjacentTileTypeIsBomb_ThenBombTileIsClosed()
        {
            // Arrange
            LevelConfiguration levelConfiguration = Create.SpecialLevelConfiguration(0, 3, 3);
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            boardGenerator.GenerateBoard();
            Filler filler = Create.Filler(boardGenerator, levelConfiguration);
            Setup.SetTypeInAllTiles(boardGenerator.ArrayOfTiles, GameTileType.Empty);
            GameTile openableTile = Setup.CentralGameTile(boardGenerator.ArrayOfTiles);
            GameTile nonEmptyTile = Setup.ZeroGameTile(boardGenerator.ArrayOfTiles);
            nonEmptyTile.Type = GameTileType.Bomb;

            // Act
            filler.FloodFill(openableTile);

            // Assert
            Assert.That(!nonEmptyTile.IsOpened);
        }


        [Test]
        public void WhenFllodFilling_AndAdjacentTileTypeIsBombIndicator_ThenBombIndicatorTileIsOpened()
        {
            // Arrange
            LevelConfiguration levelConfiguration = Create.SpecialLevelConfiguration(0, 3, 3);
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            boardGenerator.GenerateBoard();
            Filler filler = Create.Filler(boardGenerator, levelConfiguration);
            Setup.SetTypeInAllTiles(boardGenerator.ArrayOfTiles, GameTileType.Empty);
            GameTile openableTile = Setup.CentralGameTile(boardGenerator.ArrayOfTiles);
            GameTile nonEmptyTile = Setup.ZeroGameTile(boardGenerator.ArrayOfTiles);
            nonEmptyTile.Type = GameTileType.BombIndicator;

            // Act
            filler.FloodFill(openableTile);

            // Assert
            Assert.That(nonEmptyTile.IsOpened);
        }

        private bool AreAllTilesOpen(BoardGenerator boardGenerator)
        {
            for (int i = 0; i < boardGenerator.ArrayOfTiles.GetLength(0); i++)
            {
                for (int j = 0; j < boardGenerator.ArrayOfTiles.GetLength(1); j++)
                {
                    GameTile tile = boardGenerator.ArrayOfTiles[i, j];

                    if (tile.IsOpened == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool DoesEachBombHaveClues(BoardGenerator boardGenerator, LevelConfiguration levelConfiguration)
        {
            const GameTileType bombType = GameTileType.Bomb;
            const GameTileType bombIndicatorType = GameTileType.BombIndicator;
            AdjacentTilesFinder adjacentTilesFinder = Create.AdjacentTilesFinder(boardGenerator, levelConfiguration);

            for (int i = 0; i < boardGenerator.ArrayOfTiles.GetLength(0); i++)
            {
                for (int j = 0; j < boardGenerator.ArrayOfTiles.GetLength(1); j++)
                {
                    GameTile tile = boardGenerator.ArrayOfTiles[i, j];

                    if (tile.Type == bombType)
                    {
                        foreach (GameTile adjacentTile in adjacentTilesFinder.GetAdjacentTiles(tile))
                        {
                            if (adjacentTile.Type != bombIndicatorType && adjacentTile.Type != bombType)
                                return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}

