using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CobeBase.Infrastructure.AssetManagement
{
    public class AssetProvider
    {
        public async UniTask<TAsset> Load<TAsset>(string path) where TAsset : class
        {
            var prefab = await Resources.LoadAsync<GameObject>(path);
            return Object.Instantiate(prefab) as TAsset;
        }
    }
}
