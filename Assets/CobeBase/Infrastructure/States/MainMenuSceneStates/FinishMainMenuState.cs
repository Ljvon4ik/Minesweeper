using Cysharp.Threading.Tasks;

namespace CobeBase.Infrastructure.States.MainMenuSceneStates
{
    public class FinishMainMenuState : IState
    {
        private GameStateMachine _gameStateMachine;
        public FinishMainMenuState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;        
        }

        public async UniTask Enter()
        {
            _gameStateMachine.Enter<LevelState>();
        }

        public void Exit()
        {
        }
    }
}
