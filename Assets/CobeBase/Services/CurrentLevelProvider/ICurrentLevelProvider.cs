using CobeBase.Data.StaticData;

namespace CobeBase.Services.CurrentLevelProvider
{
    public interface ICurrentLevelProvider
    {
        LevelConfiguration CurrentLevelConfiguration {  get; }
    }
}