using CobeBase.Data.StaticData;

namespace CobeBase.Services.DynamicDataStorage
{
    public interface IDynamicDataStorage
    {
        public LevelType CurrentLevelType { get; }
        void UpdateCurrentLevel(LevelType levelType);
    }
}
