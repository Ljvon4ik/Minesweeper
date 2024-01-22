using CobeBase.Data.StaticData;
using CobeBase.Infrastructure.States.MainMenuSceneStates;
using CobeBase.Services.DynamicDataStorage;
using CobeBase.UI.MainMenu;
using CobeBase.UI.MainMenu.ScrollingMenu;
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
        private IDynamicDataStorage _dynamicDataStorage;

        public void Init(MainMenuStateMachine stateMachine, 
            IScrollableMenu scrollableMenu, 
            IDynamicDataStorage dynamicDataStorage)
        {
            _stateMachine = stateMachine;
            _dynamicDataStorage = dynamicDataStorage;

            _playButton.OnClickAsObservable().Subscribe(_ => Play()).AddTo(this);
            scrollableMenu.SelectedPanel.Subscribe(panel => UpdateDynamicData(panel)).AddTo(this);
        }

        private void UpdateDynamicData(LevelPanelView panel)
        {
            if(panel != null)
            {
                LevelType levelType = panel.PanelLevelType;
                _dynamicDataStorage.UpdateCurrentLevel(levelType);
            }
        }

        private void Play()
        {
            _stateMachine.Enter<FinishMainMenuState>();
        }

    }
}
