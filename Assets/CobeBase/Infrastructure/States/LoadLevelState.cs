using CobeBase.UI;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace CobeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private GameStateMachine _gameStateMachine;
        public LoadLevelState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            LoadScene().Forget();
        }

        private async UniTask LoadScene()
        {
                LoadingView _loadingView = Object.Instantiate((LoadingView) await Resources.LoadAsync<LoadingView>("LoadingView"));

                await SceneManager.LoadSceneAsync("LevelScene", LoadSceneMode.Single);

                _loadingView.Hide();

                _gameStateMachine.Enter<LevelState>();
        }

        public void Exit()
        {
        }
    }
}
