using CobeBase.UI.Factory;

namespace CobeBase.Infrastructure.States.MainMenuSceneStates
{
    public class MainMenuCreationState : IState
    {
        private IMainMenuFactory _factory;
        public MainMenuCreationState(IMainMenuFactory mainMenuUIFactory)
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
