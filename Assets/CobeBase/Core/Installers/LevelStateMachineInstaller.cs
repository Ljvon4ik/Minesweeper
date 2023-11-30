using CobeBase.Infrastructure.States;
using Zenject;
using CobeBase.Infrastructure.States.LevelSceneStates;

namespace CobeBase.Core.Installers
{
    public class LevelStateMachineInstaller : Installer<LevelStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();
            Container.Bind<LevelStateMachine>().AsSingle();
        }
    }
}
