using CobeBase.Infrastructure.SceneManagement;
using CobeBase.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CobeBase.Infrastructure.States
{
    public class LevelState : IState
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private LoadingView _loadingView;
        private LevelView _view;

        public LevelState(GameStateMachine gameStateMachine,
            SceneLoader sceneLoader,
            LoadingView loadingView)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingView = loadingView;
        }
        public async UniTask Enter()
        {
            _loadingView.Show();
            await _sceneLoader.Load("LevelScene");

            _view = Object.FindObjectOfType<LevelView>();
            _view.MainMenu += Play;

            _loadingView.Hide();
        }

        public void Exit()
        {
            _view.MainMenu -= Play;
        }
        private void Play()
        {
            _gameStateMachine.Enter<MainMenuState>();
        }
    }
}
