using CobeBase.Infrastructure.States;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StatesFactory>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
        }            
    }
}
