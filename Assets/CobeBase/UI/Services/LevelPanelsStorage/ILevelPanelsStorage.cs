using UnityEngine;

namespace Assets.CobeBase.UI.Services
{
    public interface ILevelPanelsStorage
    {
        void UpdateSelectedPanel(GameObject selectedPanel);
        GameObject SelectedPanel();
    }
}