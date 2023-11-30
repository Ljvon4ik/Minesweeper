using CobeBase.Data.StaticData;
using CobeBase.Infrastructure.AssetManagement;
using CobeBase.UI.MainMenu;
using UnityEngine;

namespace CobeBase.UI.Factory
{
    public class UILevelPanelsFactory : IUILevelPanelsFactory
    {
        private LevelsDatabase _levelsDatabase;
        private AssetProvider _assetProvider;
        public UILevelPanelsFactory(LevelsDatabase levelsDatabase, AssetProvider assetProvider)
        {
            _levelsDatabase = levelsDatabase;
            _assetProvider = assetProvider;
        }

        public LevelPanelView CreateLevelPanel(LevelType levelType, Transform parent)
        {
            string path = AssetPath.UILevelPanelPrefab;
            LevelPanelView levelPanelPresenter = _assetProvider.Instantiate<LevelPanelView>(path, parent);

            LevelConfiguration levelConfiguration = _levelsDatabase.GetInfo(levelType);
            string name = levelConfiguration.LevelName;
            int width = levelConfiguration.WidthBoard;
            int height = levelConfiguration.HeightBoard;
            int bombs = levelConfiguration.BombsCount;

            float time = default;// TODO

            levelPanelPresenter.Init(levelType, name, width, height, bombs, time);
            return levelPanelPresenter;
        }

    }
}
