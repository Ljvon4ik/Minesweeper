using CobeBase.UI.Factory;
using Cysharp.Threading.Tasks;

namespace CobeBase.Infrastructure.States.MainMenuSceneStates
{
    public class MainMenuCreationState : IState
    {
        private MainMenuUIFactory _factory;
        public MainMenuCreationState(MainMenuUIFactory mainMenuUIFactory)
        {
            _factory = mainMenuUIFactory;
        }
        public void Enter()
        {
            _factory.CreateMainMenu();
        }

        public void Exit()
        {
        }
    }
}
