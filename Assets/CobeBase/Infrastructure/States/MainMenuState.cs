using CobeBase.Infrastructure.SceneManagement;
using CobeBase.UI;
using Cysharp.Threading.Tasks;

namespace CobeBase.Infrastructure.States
{
    public class MainMenuState : IState
    {
        private SceneLoader _sceneLoader;
        private LoadingView _loadingView;

        public MainMenuState(
            SceneLoader sceneLoader,
            LoadingView loadingView)
        {
            _sceneLoader = sceneLoader;
            _loadingView = loadingView;
        }
        public async UniTask Enter()
        {
            _loadingView.Show();
            await _sceneLoader.LoadMainMenuScene();
            _loadingView.Hide();
        }

        public void Exit()
        {
        }
    }
}
