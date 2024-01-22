namespace CobeBase.Data.StaticData
{
    public class SpecialLevelConfiguration : LevelConfiguration
    {
        public void SetConfig(byte bombsCount, byte widthBoard, byte heightBoard)
        {
            LevelType = LevelType.Special;
            _bombsCount = bombsCount;
            _widthBoard = widthBoard;
            _heightBoard = heightBoard;
        }
    }
}
