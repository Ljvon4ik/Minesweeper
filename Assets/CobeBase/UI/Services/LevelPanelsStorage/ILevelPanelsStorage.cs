using CobeBase.UI.MainMenu;
using System.Collections.Generic;

namespace Assets.CobeBase.UI.Services
{
    public interface ILevelPanelsStorage
    {
        void AddPanel(LevelPanelView panelView);
        List<LevelPanelView> GetPanels();
        void CleanUp();
    }
}