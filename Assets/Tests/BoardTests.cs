using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Board;
using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Tiles;
using NUnit.Framework;
using System;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

namespace Tests
{
    public class BoardTests
    {
        [Test]
        public void WhenBoardGenerating_AndHeightAndWidthInLevelConfigurationAreNotEqual_ThenLengthOfArrayRowsInBoadrGenerationIsEqualToWidthOfLevelConfiguration()
        {
            // Arrange
            byte bombs = 0;
            byte width = 3;
            byte height = 6;
            LevelConfiguration levelConfiguration = Create.SpecialLevelConfiguration(bombs, width, height);
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);

            // Act
            boardGenerator.GenerateBoard();

            // Assert
            Assert.AreEqual(boardGenerator.TileMatrix.GetRowsMatrixCount(), levelConfiguration.WidthBoard);
        }

        [Test]
        public void WhenBoardGenerating_AndHeightAndWidthInLevelConfigurationAreNotEqual_ThenLengthOfArrayColumnsInBoadrGenerationIsEqualToHeightOfLevelConfiguration()
        {
            // Arrange
            byte bombs = 0;
            byte width = 3;
            byte height = 6;
            LevelConfiguration levelConfiguration = Create.SpecialLevelConfiguration(bombs, width, height);
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);

            // Act
            boardGenerator.GenerateBoard();

            // Assert
            Assert.AreEqual(boardGenerator.TileMatrix.GetColumnsMatrixCount(), levelConfiguration.HeightBoard);
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
            GameTile firstClickedTile = Setup.RandomGameTile(boardGenerator.TileMatrix);

            // Act
            bombInstaller.PlaceBombs(firstClickedTile);

            // Assert
            byte bombsCountLevel = 0;
            for (int i = 0; i < boardGenerator.TileMatrix.GetRowsMatrixCount(); i++)
            {
                for (int j = 0; j < boardGenerator.TileMatrix.GetColumnsMatrixCount(); j++)
                {
                    GameTile tile = boardGenerator.TileMatrix.GetTileMatrix()[i, j];
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
            BombCluesInstaller bombCluesInstaller = Create.BombCluesInstaller(boardGenerator);
            boardGenerator.GenerateBoard();
            GameTile firstClickedTile = Setup.RandomGameTile(boardGenerator.TileMatrix);
            bombInstaller.PlaceBombs(firstClickedTile);

            // Act
            bombCluesInstaller.SetBombClues();

            // Assert
            Assert.That(DoesEachBombHaveClues(boardGenerator.TileMatrix));
        }


        [Test]
        public void WhenFloodFilling_AndAdjacentTilesAreEmpty_ThenAdjacentTilesAreOpened()
        {
            // Arrange
            LevelConfiguration levelConfiguration = Create.SpecialLevelConfiguration(0, 4, 4);
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            boardGenerator.GenerateBoard();
            Filler filler = Create.Filler(boardGenerator);
            Setup.SetTypeInAllTiles(boardGenerator.TileMatrix, GameTileType.Empty);
            GameTile openableTile = Setup.CentralGameTile(boardGenerator.TileMatrix);

            // Act
            filler.FloodFill(openableTile);

            // Assert
            Assert.That(AreAllTilesOpen(boardGenerator.TileMatrix));
        }


        [Test]
        public void WhenFloodFilling_AndAdjacentTileTypeIsBomb_ThenBombTileIsClosed()
        {
            // Arrange
            LevelConfiguration levelConfiguration = Create.SpecialLevelConfiguration(0, 3, 3);
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            boardGenerator.GenerateBoard();
            Filler filler = Create.Filler(boardGenerator);
            Setup.SetTypeInAllTiles(boardGenerator.TileMatrix, GameTileType.Empty);
            GameTile openableTile = Setup.CentralGameTile(boardGenerator.TileMatrix);
            GameTile nonEmptyTile = Setup.ZeroGameTile(boardGenerator.TileMatrix);
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
            Filler filler = Create.Filler(boardGenerator);
            Setup.SetTypeInAllTiles(boardGenerator.TileMatrix, GameTileType.Empty);
            GameTile openableTile = Setup.CentralGameTile(boardGenerator.TileMatrix);
            GameTile nonEmptyTile = Setup.ZeroGameTile(boardGenerator.TileMatrix);
            nonEmptyTile.Type = GameTileType.BombIndicator;

            // Act
            filler.FloodFill(openableTile);

            // Assert
            Assert.That(nonEmptyTile.IsOpened);
        }

        [Test]
        public void WhenEasyDigging_AndAdjacentTileTypeIsEmpty_ThenAdjacentTilesOfEmptyTileAreOpen()
        {
            // Arrange
            LevelConfiguration levelConfiguration = Create.SpecialLevelConfiguration(0, 3, 3);
            BoardGenerator boardGenerator = Setup.BoardGenerator(levelConfiguration);
            AutoDigger digger = Create.AutoDigger(boardGenerator);
            boardGenerator.GenerateBoard();
            Setup.SetTypeInAllTiles(boardGenerator.TileMatrix, GameTileType.Empty);
            GameTile tile = Setup.CentralGameTile(boardGenerator.TileMatrix);

            // Act
            digger.EasyDig(tile);

            // Assert
            Assert.That(AreAdjacentTilesOpen(tile, boardGenerator.TileMatrix));
        }

        private bool AreAdjacentTilesOpen(GameTile tile, TileMatrix tileMatrix)
        {
            foreach (GameTile adjacentTile in AdjacentTilesFinder.GetAdjacentTiles(tile, tileMatrix))
            {
                if(!adjacentTile.IsOpened)
                    return false;
            }

            return true;
        }

        private bool AreAllTilesOpen(TileMatrix matrix)
        {
            for (int i = 0; i < matrix.GetRowsMatrixCount(); i++)
            {
                for (int j = 0; j < matrix.GetColumnsMatrixCount(); j++)
                {
                    GameTile tile = matrix.GetTileMatrix()[i, j];

                    if (tile.IsOpened == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool DoesEachBombHaveClues(TileMatrix matrix)
        {
            const GameTileType bombType = GameTileType.Bomb;
            const GameTileType bombIndicatorType = GameTileType.BombIndicator;
            for (int i = 0; i < matrix.GetRowsMatrixCount(); i++)
            {
                for (int j = 0; j < matrix.GetColumnsMatrixCount(); j++)
                {
                    GameTile tile = matrix.GetTileMatrix()[i, j];

                    if (tile.Type == bombType)
                    {
                        foreach (GameTile adjacentTile in AdjacentTilesFinder.GetAdjacentTiles(tile, matrix))
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

