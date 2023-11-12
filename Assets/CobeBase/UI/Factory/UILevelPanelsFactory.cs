using CobeBase.Data.StaticData;
using CobeBase.Infrastructure.AssetManagement;
using CobeBase.UI.MainMenu;
using UnityEngine;

namespace CobeBase.UI.Factory
{
    public class UILevelPanelsFactory
    {
        private LevelsDatabase _levelsDatabase;
        private AssetProvider _assetProvider;
        public UILevelPanelsFactory(LevelsDatabase levelsDatabase, AssetProvider assetProvider)
        {
            _levelsDatabase = levelsDatabase;
            _assetProvider = assetProvider;
        }

        public LevelPanelPresenter CreateLevelPanel(LevelType levelType, Transform parent)
        {
            string path = AssetPath.UILevelPanelPrefab;
            LevelPanelPresenter levelPanelPresenter = _assetProvider.Instantiate<LevelPanelPresenter>(path, parent);

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
