using CobeBase.Data.StaticData;
using TMPro;
using UnityEngine;

namespace CobeBase.UI.MainMenu
{
    public class LevelPanelPresenter : MonoBehaviour
    {
        public LevelType PanelLevelType { get; private set; }

        [SerializeField] private TextMeshProUGUI _levelNameTxt;
        [SerializeField] private TextMeshProUGUI _boardSizeTxt;
        [SerializeField] private TextMeshProUGUI _bombsCountTxt;
        [SerializeField] private TextMeshProUGUI _bestTimeTxt;

        public void Init(LevelType levelType,
            string levelName, 
            int widthBoard, 
            int heightBoard, 
            int bombsCount, 
            float bestTime)
        {
            PanelLevelType = levelType;
            _levelNameTxt.text = levelName;
            _boardSizeTxt.text = $"Size: {widthBoard} * {heightBoard}";
            _bestTimeTxt.text = $"Bombs: {bombsCount}";
            _bestTimeTxt.text = $"Best Time: {bestTime}";
        }
    }
}
