using CobeBase.Infrastructure.States;
using CobeBase.Infrastructure.States.MainMenuSceneStates;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class MainMenuStateMachineInstaller : Installer<MainMenuStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();
            Container.Bind<MainMenuStateMachine>().AsSingle();
        }
    }
}
