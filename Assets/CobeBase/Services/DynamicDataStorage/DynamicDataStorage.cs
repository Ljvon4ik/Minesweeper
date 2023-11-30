using CobeBase.Data.StaticData;

namespace CobeBase.Services.DynamicDataStorage
{
    public class DynamicDataStorage : IDynamicDataStorage
    {
        public LevelType CurrentLevel { get; private set; } = LevelType.Easy;

        public void UpdateCurrentLevel(LevelType levelType)
        {
            CurrentLevel = levelType;
        }
    }
}
