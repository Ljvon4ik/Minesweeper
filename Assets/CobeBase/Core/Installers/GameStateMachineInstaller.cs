using CobeBase.Infrastructure.States;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();

            Container.Bind<GameStateMachine>().AsSingle();

        }
    }
}
