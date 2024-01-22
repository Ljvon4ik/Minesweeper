using CobeBase.Infrastructure.AssetManagement;
using CobeBase.Infrastructure.States.MainMenuSceneStates;
using CobeBase.Data.StaticData;
using UnityEngine;
using Assets.CobeBase.UI.Services;
using CobeBase.UI.MainMenu.ScrollingMenu;
using UnityEngine.UI;
using CobeBase.UI.MainMenu;
using CobeBase.Services.DynamicDataStorage;

namespace CobeBase.UI.Factory
{
    public class MainMenuUIFactory : IMainMenuFactory
    {
        private readonly IUILevelPanelsFactory _levelPanelsFactory;
        private readonly MainMenuStateMachine _mainMenuStateMachine;
        private MainMenuPresenter _mainMenuPresenter;
        private readonly LevelsDatabase _levelsDatabase;
        private readonly ILevelPanelsStorage _levelsPanelsStorage;
        private readonly IDynamicDataStorage _dynamicDataStorage;
        private HorizontalScroller _scrollableMenu;
        public MainMenuUIFactory(
            IUILevelPanelsFactory uILevelPanelsFactory,
            MainMenuStateMachine mainMenuStateMachine,
            LevelsDatabase levelsDatabase,
            ILevelPanelsStorage levelPanelsStorage,
            IDynamicDataStorage dynamicDataStorage)
        {
            _levelPanelsFactory = uILevelPanelsFactory;
            _mainMenuStateMachine = mainMenuStateMachine;
            _levelsDatabase = levelsDatabase;
            _levelsPanelsStorage = levelPanelsStorage;
            _dynamicDataStorage = dynamicDataStorage;
        }

        public void CreateMainMenu()
        {
            CreateUIRoot();
            CreateScrollView();
            CreateLevelPanels();
            InitCreatedObjects();
        }

        private void InitCreatedObjects()
        {
            _mainMenuPresenter.Init(_mainMenuStateMachine, _scrollableMenu, _dynamicDataStorage);
            _scrollableMenu.Init(_levelsPanelsStorage);
        }

        private void CreateScrollView()
        {
            string path = AssetPath.ScrollMenuPrefab;
            Transform parent = _mainMenuPresenter.transform;
            _scrollableMenu = AssetProvider.Instantiate<HorizontalScroller>(path, parent);
        }

        private void CreateLevelPanels()
        {
            int numberOfLevels = _levelsDatabase.NumberOfLevels();
            Transform parent = _scrollableMenu.gameObject.GetComponent<ScrollRect>().content.transform;

            for (int i = 0; i < numberOfLevels; i++)
            {
                LevelType levelType = (LevelType)i;
                LevelPanelView panel = _levelPanelsFactory.CreateLevelPanel(levelType, parent);
                _levelsPanelsStorage.AddPanel(panel);
            }
        }

        private void CreateUIRoot()
        {
            string path = AssetPath.UIRoot;
            _mainMenuPresenter = AssetProvider.Instantiate<MainMenuPresenter>(path);
        }
    }
}
