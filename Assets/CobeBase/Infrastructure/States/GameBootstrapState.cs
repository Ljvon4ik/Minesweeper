using CobeBase.Infrastructure.States;
using CobeBase.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.CobeBase.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private GameStateMachine _gameStateMachine;
        public GameBootstrapState(GameStateMachine gameStateMachine)
        { 
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            LoadScene().Forget();
        }

        private async UniTask LoadScene()
        {
            LoadingView _loadingView = Object.Instantiate((LoadingView)await Resources.LoadAsync<LoadingView>("LoadingView"));

            await SceneManager.LoadSceneAsync("MainMenuScene", LoadSceneMode.Single);

            _loadingView.Hide();

            _gameStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
        }
    }
}
