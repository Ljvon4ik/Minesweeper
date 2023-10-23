using CobeBase.UI;
using Cysharp.Threading.Tasks;
using CobeBase.Infrastructure.SceneManagement;
using System.Diagnostics;
using CobeBase.Services.LogService;

namespace CobeBase.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private LoadingView _loadingView;
        private ILogService _logService;

        public GameBootstrapState(GameStateMachine gameStateMachine, 
            SceneLoader sceneLoader, 
            LoadingView loadingView,
            ILogService logService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingView = loadingView;
            _logService = logService;
        }

        public async UniTask Enter()
        {
            _loadingView.Show();
            await InitServices();
            _gameStateMachine.Enter<MainMenuState>();
        }

        private async UniTask InitServices()
        {
            _logService.Log("Init Services");
        }

        public void Exit()
        {
            _loadingView.Hide();
        }
    }
}
