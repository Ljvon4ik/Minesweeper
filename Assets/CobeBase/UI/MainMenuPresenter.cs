using CobeBase.Infrastructure.States.MainMenuSceneStates;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace CobeBase.UI
{
    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton;

        private MainMenuStateMachine _stateMachine;

        public void Init(MainMenuStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Start()
        {
            _playButton?.OnClickAsObservable().Subscribe(_ => Play()).AddTo(this);
        }
        private void Play()
        {
            _stateMachine.Enter<FinishMainMenuState>();
        }

    }
}
