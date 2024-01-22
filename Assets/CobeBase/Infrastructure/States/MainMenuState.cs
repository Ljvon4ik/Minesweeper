using CobeBase.Infrastructure.SceneManagement;
using CobeBase.UI;
using Cysharp.Threading.Tasks;

namespace CobeBase.Infrastructure.States
{
    public class MainMenuState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingView _loadingView;

        public MainMenuState(
            SceneLoader sceneLoader,
            LoadingView loadingView)
        {
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
            await _sceneLoader.LoadMainMenuScene();
            NextAction();
        }

        private void NextAction()
        {
            _loadingView.Hide();
        }

        public void Exit()
        {
        }
    }
}
