using CobeBase.Data.StaticData;
using CobeBase.UI.MainMenu;
using UnityEngine;

namespace CobeBase.UI.Factory
{
    public interface IUILevelPanelsFactory
    {
        LevelPanelView CreateLevelPanel(LevelType levelType, Transform parent);
    }
}