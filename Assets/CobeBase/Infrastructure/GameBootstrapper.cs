using UnityEngine;
using CobeBase.Infrastructure.States;
using Zenject;
using Assets.CobeBase.Infrastructure.States;

namespace CobeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private StatesFactory _statesFactory;

        [Inject]
        void Construct(GameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;
        }

        private void Start()
        {
            _gameStateMachine.AddState(_statesFactory.Create<GameBootstrapState>());
            _gameStateMachine.AddState(_statesFactory.Create<MainMenuState>());
            _gameStateMachine.AddState(_statesFactory.Create<LevelState>());
            _gameStateMachine.AddState(_statesFactory.Create<LoadLevelState>());
            _gameStateMachine.AddState(_statesFactory.Create<LoadMainMenuState>());

            _gameStateMachine.Enter<GameBootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
