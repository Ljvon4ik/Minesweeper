using CobeBase.Data.StaticData;
using CobeBase.Services.DynamicDataStorage;

namespace CobeBase.Services.CurrentLevelProvider
{
    public class CurrentLevelProvider : ICurrentLevelProvider
    {
        private LevelConfiguration _currentLevelConfig;
        public LevelConfiguration CurrentLevelConfiguration 
        {  
            get 
            { 
                if(_currentLevelConfig == null)
                {
                    AssignCurrentLevelConfig();
                }
                return _currentLevelConfig; 
            } 
        }
        private readonly LevelsDatabase _levelsDatabase;
        private readonly IDynamicDataStorage _dynamicDataStorage;

        public CurrentLevelProvider(LevelsDatabase levelsDatabase, IDynamicDataStorage dynamicDataStorage)
        {
            _levelsDatabase = levelsDatabase;
            _dynamicDataStorage = dynamicDataStorage;
        }

        private void AssignCurrentLevelConfig()
        {
            LevelType level = _dynamicDataStorage.CurrentLevelType;
            LevelConfiguration configuration = _levelsDatabase.GetInfo(level);
            _currentLevelConfig = configuration;
        }
    }
}
