using Zenject;

namespace CobeBase.Infrastructure.States.LevelSceneStates
{
    public class LevelBootstraper : IInitializable
    {
        private LevelStateMachine _levelStateMachine;
        private StatesFactory _statesFactory;

        public LevelBootstraper(LevelStateMachine stateMachine, StatesFactory statesFactory)
        {
            _levelStateMachine = stateMachine;
            _statesFactory = statesFactory;
        }
        public void Initialize()
        {
            _levelStateMachine.AddState(_statesFactory.Create<LevelCreationState>());
            _levelStateMachine.AddState(_statesFactory.Create<FinishLevelState>());

            _levelStateMachine.Enter<LevelCreationState>();
        }
    }
}
