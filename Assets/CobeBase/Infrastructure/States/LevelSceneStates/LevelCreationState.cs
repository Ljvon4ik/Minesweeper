using CobeBase.Data.StaticData;
using CobeBase.CameraLogic;
using UnityEngine;
using CobeBase.Gameplay.Board;
using CobeBase.Services.CurrentLevelProvider;

namespace CobeBase.Infrastructure.States.LevelSceneStates
{
    public class LevelCreationState : IState
    {
        private readonly ICurrentLevelProvider _currentLevelProvider;
        private readonly GameBoard _gameBoard;

        public LevelCreationState(ICurrentLevelProvider currentLevelProvider,
            GameBoard gameBoard)
        {
            _currentLevelProvider = currentLevelProvider;
            _gameBoard = gameBoard;
        }

        public void Enter()
        {
            _gameBoard.GenerateBoard();
            InitCamera();
        }

        private void InitCamera()
        {
            LevelConfiguration configuration = _currentLevelProvider.CurrentLevelConfiguration;
            byte width = configuration.WidthBoard;
            byte height = configuration.HeightBoard;

            CameraController camera = Camera.main.GetComponent<CameraController>();
            camera.Init(width, height);
        }

        public void Exit()
        {
        }
    }
}
