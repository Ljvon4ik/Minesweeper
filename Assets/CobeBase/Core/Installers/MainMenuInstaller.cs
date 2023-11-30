using Assets.CobeBase.UI.Services;
using CobeBase.Infrastructure.States.MainMenuSceneStates;
using CobeBase.Services.LogService;
using CobeBase.UI.Factory;
using CobeBase.UI.MainMenu.ScrollingMenu;
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
            Container.BindInterfacesAndSelfTo<UILevelPanelsFactory>().AsSingle();
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
            Container.BindInterfacesAndSelfTo<MainMenuUIFactory>().AsSingle();
        }

    }
}
