using CobeBase.Infrastructure.AssetManagement;
using CobeBase.Infrastructure.SceneManagement;
using CobeBase.Infrastructure.States;
using CobeBase.Services.LogService;
using CobeBase.UI;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILogService>().To<LogService>().AsSingle();
            Container.Bind<StatesFactory>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<AssetLabels>().AsSingle();
            Container.Bind<AssetProvider>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            BindLoadingView();
        }
        private void BindLoadingView()
        {
            Container.Bind<LoadingView>()
                .FromComponentInNewPrefabResource(AssetLabels.LoadingView)
                .AsSingle();
        }
    }
}
