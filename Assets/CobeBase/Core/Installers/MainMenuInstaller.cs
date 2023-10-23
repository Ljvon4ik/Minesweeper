using CobeBase.Data.StaticData;
using CobeBase.MainMenu;
using CobeBase.UI;
using System;
using UnityEngine;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] MainMenuView _mainMenuView;

        public override void InstallBindings()
        {
            BindView();
            BindPresenter();
        }

        private void BindPresenter()
        {
            Container
                .BindInterfacesTo<MainMenuPresenter>()
                .AsSingle();
        }

        private void BindView()
        {
            Container
            .Bind<MainMenuView>()
                .FromInstance(_mainMenuView)
                .AsSingle();
        }

    }
}
