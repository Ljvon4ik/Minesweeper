using CobeBase.UI.MainMenu;
using System.Collections.Generic;

namespace Assets.CobeBase.UI.Services
{
    public class LevelPanelsStorage : ILevelPanelsStorage
    {
        private List<LevelPanelView> _panels = new();

        public void AddPanel(LevelPanelView panelView)
        {
            if(_panels.Contains(panelView))
                return;

            _panels.Add(panelView);
        }

        public List<LevelPanelView> GetPanels()
        {
            return _panels;
        }

        public void CleanUp()
        {
            _panels.Clear();
        }
    }
}
