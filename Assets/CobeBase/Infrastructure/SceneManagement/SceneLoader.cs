using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace CobeBase.Infrastructure.SceneManagement
{
    public class SceneLoader
    {
        private readonly string _levelSceneName = "LevelScene";
        private readonly string _mainMenuSceneName = "MainMenuScene";

        public async UniTask LoadLevelScene()
        {
            await SceneManager.LoadSceneAsync(_levelSceneName, LoadSceneMode.Single);
        }
        public async UniTask LoadMainMenuScene()
        {
            await SceneManager.LoadSceneAsync(_mainMenuSceneName, LoadSceneMode.Single);
        }
    }
}
