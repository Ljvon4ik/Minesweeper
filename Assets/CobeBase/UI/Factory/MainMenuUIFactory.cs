using CobeBase.Infrastructure.AssetManagement;
using CobeBase.Infrastructure.States.MainMenuSceneStates;
using CobeBase.Data.StaticData;
using UnityEngine;
using Assets.CobeBase.UI.Services;
using CobeBase.UI.MainMenu.ScrollingMenu;
using UnityEngine.UI;

namespace CobeBase.UI.Factory
{
    public class MainMenuUIFactory
    {
        private AssetProvider _assetProvider;
        private UILevelPanelsFactory _levelPanelsFactory;
        private MainMenuStateMachine _mainMenuStateMachine;
        private MainMenuPresenter _mainMenuPresenter;
        private HorizontalScroller _horizontalScroller;
        private LevelsDatabase _levelsDatabase;
        private ILevelPanelsStorage _levelsPanelsStorage;

        public MainMenuUIFactory(AssetProvider assetProveder,
            UILevelPanelsFactory uILevelPanelsFactory,
            MainMenuStateMachine mainMenuStateMachine,
            LevelsDatabase levelsDatabase,
            ILevelPanelsStorage levelPanelsStorage)
        {
            _assetProvider = assetProveder;
            _levelPanelsFactory = uILevelPanelsFactory;
            _mainMenuStateMachine = mainMenuStateMachine;
            _levelsDatabase = levelsDatabase;
            _levelsPanelsStorage = levelPanelsStorage;
        }

        public void CreateMainMenu()
        {
            CreateUIRoot();
            CreateScrollView();
            CreateLevelPanels();
        }

        private void CreateScrollView()
        {
            string path = AssetPath.ScrollMenuPrefab;
            Transform parent = _mainMenuPresenter.transform;
            _horizontalScroller = _assetProvider.Instantiate<HorizontalScroller>(path, parent);
            _horizontalScroller.Init(_levelsPanelsStorage);
        }

        private void CreateLevelPanels()
        {
            int numberOfLevels = _levelsDatabase.NumberOfLevels();
            Transform parent = _horizontalScroller.gameObject.GetComponent<ScrollRect>().content.transform;

            for (int i = 0; i < numberOfLevels; i++)
            {
                LevelType levelType = (LevelType)i;
                _levelPanelsFactory.CreateLevelPanel(levelType, parent);
            }
        }

        private void CreateUIRoot()
        {
            string path = AssetPath.UIRoot;
            _mainMenuPresenter = _assetProvider.Instantiate<MainMenuPresenter>(path);
            _mainMenuPresenter.Init(_mainMenuStateMachine);
        }
    }
}
