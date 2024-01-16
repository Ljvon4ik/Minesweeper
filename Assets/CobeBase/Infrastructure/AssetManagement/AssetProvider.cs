using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace CobeBase.Infrastructure.AssetManagement
{
    public class AssetProvider
    {
        //public async UniTask<TAsset> InstantiateAsync<TAsset>(string path) where TAsset : class
        //{
        //    var prefab = await Resources.LoadAsync(path, typeof(TAsset));
        //    Assert.IsNotNull(prefab, $"Asset with component {typeof(TAsset)} not found");
        //    return Object.Instantiate(prefab) as TAsset;
        //}

        //public async UniTask<TAsset> InstantiateAsync<TAsset>(string path, Transform parent) where TAsset : class
        //{
        //    var prefab = await Resources.LoadAsync(path, typeof(TAsset));
        //    Assert.IsNotNull(prefab, $"Asset with component {typeof(TAsset)} not found");
        //    return Object.Instantiate(prefab, parent) as TAsset;
        //}

        public static TAsset Instantiate<TAsset>(string path) where TAsset : class
        {
            var prefab = Resources.Load(path, typeof(TAsset));
            Assert.IsNotNull(prefab, $"Asset with component {typeof(TAsset)} not found");
            return Object.Instantiate(prefab) as TAsset;
        }

        public static TAsset Instantiate<TAsset>(string path, Transform parent) where TAsset : class
        {
            var prefab = Resources.Load(path, typeof(TAsset));
            Assert.IsNotNull(prefab, $"Asset with component {typeof(TAsset)} not found");
            return Object.Instantiate(prefab, parent) as TAsset;
        }

        public static TAsset Instantiate<TAsset>(string path, Vector3 position, Transform parent) where TAsset : class
        {
            var prefab = Resources.Load(path, typeof(TAsset));
            Assert.IsNotNull(prefab, $"Asset with component {typeof(TAsset)} not found");
            return Object.Instantiate(prefab, position, Quaternion.identity, parent) as TAsset;
        }
    }
}
