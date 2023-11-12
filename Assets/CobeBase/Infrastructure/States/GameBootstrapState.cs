using CobeBase.UI;
using CobeBase.Infrastructure.SceneManagement;
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

        public void Enter()
        {
            _loadingView.Show();
            _gameStateMachine.Enter<MainMenuState>();
        }


        public void Exit()
        {
            _loadingView.Hide();
        }
    }
}
