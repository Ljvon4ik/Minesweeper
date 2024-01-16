using CobeBase.Data.StaticData;

namespace CobeBase.Services.DynamicDataStorage
{
    public class DynamicDataStorage : IDynamicDataStorage
    {
        public LevelType CurrentLevelType { get; private set; } = LevelType.Easy;

        public void UpdateCurrentLevel(LevelType levelType)
        {
            CurrentLevelType = levelType;
        }
    }
}
