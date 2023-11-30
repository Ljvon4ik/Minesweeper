using UniRx;

namespace CobeBase.UI.MainMenu.ScrollingMenu
{
    public interface IScrollableMenu
    {
        public ReactiveProperty<LevelPanelView> SelectedPanel { get; }
    }
}