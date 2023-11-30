using CobeBase.Data.StaticData;
using CobeBase.Infrastructure.AssetManagement;
using CobeBase.Services.DynamicDataStorage;
using CobeBase.Gameplay;
using CobeBase.CameraLogic;
using UnityEngine;
using CobeBase.Services.InputServices;
using System;
using CobeBase.Gameplay.Factories;

namespace CobeBase.Infrastructure.States.LevelSceneStates
{
    public class LevelCreationState : IState
    {
        private AssetProvider _assetProvider;
        private IDynamicDataStorage _dynamicDataStorage;
        private LevelsDatabase _levelsDatabase;
        private IInputService _inputService;
        private GameTileContentFactory _gameTileContentFactory;

        public LevelCreationState(AssetProvider assetProvider, 
            IDynamicDataStorage dynamicDataStorage,
            LevelsDatabase levelsDatabase,
            IInputService inputService,
            GameTileContentFactory gameTileContentFactory)
        {
            _assetProvider = assetProvider;
            _dynamicDataStorage = dynamicDataStorage;
            _levelsDatabase = levelsDatabase;
            _inputService = inputService;
            _gameTileContentFactory = gameTileContentFactory;
        }

        public void Enter()
        {
            GameBoard gameBoard = CreateGameBoard();
            InitGameBoard(gameBoard);
            InitCamera();
        }

        private void InitCamera()
        {
            LevelType level = _dynamicDataStorage.CurrentLevel;
            LevelConfiguration levelConfiguration = _levelsDatabase.GetInfo(level);

            byte width = levelConfiguration.WidthBoard;
            byte height = levelConfiguration.HeightBoard;

            CameraController camera = Camera.main.GetComponent<CameraController>();
            camera.Init(width, height);
        }

        private void InitGameBoard(GameBoard gameBoard)
        {
            LevelType level = _dynamicDataStorage.CurrentLevel;
            LevelConfiguration levelConfiguration = _levelsDatabase.GetInfo(level);
            gameBoard.Init(levelConfiguration, _assetProvider, _inputService, _gameTileContentFactory);
        }

        private GameBoard CreateGameBoard()
        {
            string path = AssetPath.GameBoard;
            GameBoard gameBoard = _assetProvider.Instantiate<GameBoard>(path);
            return gameBoard;
        }

        public void Exit()
        {
        }
    }
}
