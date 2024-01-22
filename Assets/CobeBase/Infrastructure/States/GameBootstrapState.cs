using CobeBase.UI;
using CobeBase.Services.LogService;

namespace CobeBase.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoadingView _loadingView;

        public GameBootstrapState(GameStateMachine gameStateMachine, 
            LoadingView loadingView,
            ILogService logService)
        {
            _gameStateMachine = gameStateMachine;
            _loadingView = loadingView;
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
