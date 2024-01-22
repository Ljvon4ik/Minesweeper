using CobeBase.Gameplay.Board;
using CobeBase.Infrastructure.States.LevelSceneStates;
using CobeBase.Services.CurrentLevelProvider;
using CobeBase.Services.InputServices;
using CodeBase.Input;
using UnityEngine;
using Zenject;

namespace CobeBase.Core.Installers
{
    public partial class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindBootstraper();
            BindInputService();
            BindCamera();
            BindCurrentLevelProvider();
            BindGameBoard();
            BindInput();
        }

        private void BindInput()
        {
            Container.Bind<MyNewInput>().AsSingle();
        }

        private void BindCurrentLevelProvider()
        {
            Container.BindInterfacesAndSelfTo<CurrentLevelProvider>().AsSingle();
        }

        private void BindGameBoard()
        {
            GameBoardInstaller.Install(Container);
        }

        private void BindCamera()
        {
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
        }

        private void BindInputService()
        {
            Container.BindInterfacesAndSelfTo<MouseInput>().AsSingle();
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
