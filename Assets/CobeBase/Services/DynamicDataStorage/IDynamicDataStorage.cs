using CobeBase.Data.StaticData;

namespace CobeBase.Services.DynamicDataStorage
{
    public interface IDynamicDataStorage
    {
        public LevelType CurrentLevel { get; }
        void UpdateCurrentLevel(LevelType levelType);
    }
}
