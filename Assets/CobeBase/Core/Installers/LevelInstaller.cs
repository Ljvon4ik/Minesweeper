using CobeBase.Gameplay.Factories;
using CobeBase.Infrastructure.States.LevelSceneStates;
using CobeBase.Services.InputServices;
using System;
using UnityEngine;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindBootstraper();
            BindInputService();
            BindCamera();
            BindGameTileContentFactory();
        }

        private void BindGameTileContentFactory()
        {
            Container.Bind<GameTileContentFactory>().AsSingle();
        }

        private void BindCamera()
        {
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
        }

        private void BindInputService()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle();
        }

        private void BindBootstraper()
        {
            Container.BindInterfacesAndSelfTo<LevelBootstraper>().AsSingle().NonLazy();
        }

        private void BindStateMachine()
        {
            LevelStateMachineInstaller.Install(Container);
        }
    }
}
