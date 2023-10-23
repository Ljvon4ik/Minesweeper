using CobeBase.MainMenu;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CobeBase.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton;
        private IPresenter _presenter;

        [Inject]
        private void Construct(IPresenter mainMenuPresenter)
        {
            _presenter = mainMenuPresenter;
        }


        private void Start()
        {
            _playButton.onClick.AsObservable().Subscribe(_ => _presenter.Play());
        }
    }
}
