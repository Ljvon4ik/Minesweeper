using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace CobeBase.UI
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField]
        private Button _mainMenuButton;

        public event UnityAction MainMenu
        {
            add
            {
                _mainMenuButton.onClick.AddListener(value);
            }
            remove
            {
                _mainMenuButton.onClick.RemoveListener(value);
            }
        }
    }

}
