using Zenject;

namespace CobeBase.Infrastructure.States.MainMenuSceneStates

{
    public class MainMenuBootstraper : IInitializable
    {
        private readonly MainMenuStateMachine _mainMenuStateMachine;
        private readonly StatesFactory _statesFactory;

        public MainMenuBootstraper(MainMenuStateMachine stateMachine, StatesFactory statesFactory)
        {
            _mainMenuStateMachine = stateMachine;
            _statesFactory = statesFactory;
        }

        public void Initialize()
        {
            _mainMenuStateMachine.AddState(_statesFactory.Create<MainMenuCreationState>());
            _mainMenuStateMachine.AddState(_statesFactory.Create<FinishMainMenuState>());

            _mainMenuStateMachine.Enter<MainMenuCreationState>();
        }
    }
}
