using CobeBase.Data.StaticData;
using CobeBase.UI.MainMenu;
using UnityEngine;

namespace Assets.CobeBase.UI.Services
{
    public class LevelPanelsStorage : ILevelPanelsStorage
    {
        private GameObject _selectedPanel;
        public GameObject SelectedPanel()
        {
            return _selectedPanel;
        }

        public void UpdateSelectedPanel(GameObject selectedPanel)
        {
            _selectedPanel = selectedPanel;
        }

        private LevelType Convert(GameObject selectedPanel)
        {
            LevelType selectedLevel = selectedPanel.GetComponent<LevelPanelPresenter>().PanelLevelType;
            return selectedLevel;
        }
    }
}
