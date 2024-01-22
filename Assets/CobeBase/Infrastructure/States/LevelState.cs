using CobeBase.Infrastructure.SceneManagement;
using CobeBase.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CobeBase.Infrastructure.States
{
    public class LevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingView _loadingView;
        private LevelView _view;

        public LevelState(GameStateMachine gameStateMachine,
            SceneLoader sceneLoader,
            LoadingView loadingView)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingView = loadingView;
        }
        public void Enter()
        {
            _loadingView.Show();
            LoadNextScene().Forget();
        }

        private async UniTask LoadNextScene()
        {
            await _sceneLoader.LoadLevelScene();
            NextAction();
        }

        private void NextAction()
        {
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
