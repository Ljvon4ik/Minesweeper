using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Board;
using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Factories;
using CobeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace Tests
{
    public class Create
    {
        public static BoardGenerator BoardGenerator()
        {
            return new GameObject().AddComponent<BoardGenerator>();
        }

        public static GameTileContentFactory ContentFactory()
        {
            return new();
        }

        public static LevelsDatabase LevelsDatabase()
        {
            return Resources.Load<LevelsDatabase>(AssetPath.LevelsDatabase);
        }

        public static BombInstaller BombInstaller(BoardGenerator boardGenerator, LevelConfiguration levelConfiguration)
        {
            BombInstaller bombInstaller = new(Setup.CurrentLevelProvider(levelConfiguration), boardGenerator);
            return bombInstaller;
        }

        public static BombCluesInstaller BombCluesInstaller(BoardGenerator boardGenerator, LevelConfiguration levelConfiguration)
        {
            BombCluesInstaller bombCluesInstaller = new(AdjacentTilesFinder(boardGenerator, levelConfiguration), boardGenerator);
            return bombCluesInstaller;
        }

        public static AdjacentTilesFinder AdjacentTilesFinder(BoardGenerator boardGenerator, LevelConfiguration levelConfiguration)
        {
            AdjacentTilesFinder adjacentTilesFinder = new(Setup.CurrentLevelProvider(levelConfiguration), boardGenerator);
            return adjacentTilesFinder;
        }
        public static LevelConfiguration LevelConfiguration(LevelType levelType = LevelType.Easy)
        {
            LevelsDatabase levelsDatabase = Create.LevelsDatabase();
            return levelsDatabase.GetInfo(levelType);
        }

        public static LevelConfiguration SpecialLevelConfiguration(byte bombsCount, byte widthBoard, byte heightBoard)
        {
            SpecialLevelConfiguration levelConfiguration = ScriptableObject.CreateInstance<SpecialLevelConfiguration>();
            levelConfiguration.SetConfig(bombsCount, widthBoard, heightBoard);
            return levelConfiguration;
        }

        public static Filler Filler(BoardGenerator boardGenerator, LevelConfiguration levelConfiguration)
        {
            Filler filler = new(AdjacentTilesFinder(boardGenerator, levelConfiguration));
            return filler;
        }
    }
}
