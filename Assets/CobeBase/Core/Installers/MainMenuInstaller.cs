using Assets.CobeBase.UI.Services;
using CobeBase.Infrastructure.States.MainMenuSceneStates;
using CobeBase.UI.Factory;
using System;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindUIFactory();
            BindBootstraper();
            BindUILevelPanelsFactory();
            BindLevelPanelsStorage();
        }

        private void BindLevelPanelsStorage()
        {
            Container.BindInterfacesAndSelfTo<LevelPanelsStorage>().AsSingle();
        }

        private void BindUILevelPanelsFactory()
        {
            Container.Bind<UILevelPanelsFactory>().AsSingle();
        }

        private void BindBootstraper()
        {
            Container.BindInterfacesAndSelfTo<MainMenuBootstraper>().AsSingle().NonLazy();
        }

        private void BindStateMachine()
        {
            MainMenuStateMachineInstaller.Install(Container);
        }

        private void BindUIFactory()
        {
            Container.Bind<MainMenuUIFactory>().AsSingle();
        }

    }
}
