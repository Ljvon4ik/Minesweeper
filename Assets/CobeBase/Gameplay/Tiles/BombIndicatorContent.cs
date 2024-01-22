using TMPro;
using UnityEngine;

namespace CobeBase.Gameplay.Tiles
{
    public class BombIndicatorContent : GameTileContent
    {
        [SerializeField] private TextMeshProUGUI _text;
        public void SetValue(int value)
        {
            _text.text = value.ToString();
        }
    }
}
