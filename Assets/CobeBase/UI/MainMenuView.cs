using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CobeBase.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton;

        public event UnityAction Play
        {
            add
            {
                _playButton.onClick.AddListener(value);
            }
            remove
            {
                _playButton.onClick.RemoveListener(value);
            }
        }
    }
}
