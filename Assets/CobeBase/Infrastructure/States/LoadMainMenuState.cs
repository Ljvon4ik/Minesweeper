using CobeBase.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CobeBase.Infrastructure.States
{
    public class LoadMainMenuState : IState
    {
        private GameStateMachine _gameStateMachine;

        public LoadMainMenuState(GameStateMachine gameStateMachine)
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
