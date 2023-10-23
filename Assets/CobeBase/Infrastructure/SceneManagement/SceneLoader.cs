using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace CobeBase.Infrastructure.SceneManagement
{
    public class SceneLoader
    {
        public async UniTask Load(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
    }
}
