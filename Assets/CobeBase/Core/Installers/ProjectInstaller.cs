using CobeBase.Data.StaticData;
using CobeBase.Infrastructure.AssetManagement;
using CobeBase.Infrastructure.SceneManagement;
using CobeBase.Services.LogService;
using CobeBase.UI;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLogService();
            BindGameStateMachine();
            BindAssetProvider();
            BindSceneLoader();
            BindLoadingView();
            BindLevelsDatabase();
        }

        private void BindLevelsDatabase()
        {
            Container.Bind<LevelsDatabase>().FromScriptableObjectResource(AssetPath.LevelsDatabase).AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void BindAssetProvider()
        {
            Container.Bind<AssetProvider>().AsSingle();
        }

        private void BindGameStateMachine()
        {
            GameStateMachineInstaller.Install(Container);
        }

        private void BindLogService()
        {
            Container.Bind<ILogService>().To<LogService>().AsSingle();
        }

        private void BindLoadingView()
        {
            Container.Bind<LoadingView>()
                .FromComponentInNewPrefabResource(AssetPath.LoadingView)
                .AsSingle();
        }
    }
}
