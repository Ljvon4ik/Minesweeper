using System;
using UnityEngine;

namespace CobeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Data/Level Config")]
    public class LevelConfiguration : ScriptableObject
    {
        public LevelType Type;
        [SerializeField] protected byte _widthBoard;
        [SerializeField] protected byte _heightBoard;
        [SerializeField] protected byte _bombsCount;

        public string LevelName => Enum.GetName(typeof(LevelType), Type);
        public byte BombsCount => _bombsCount;
        public byte WidthBoard => _widthBoard;
        public byte HeightBoard => _heightBoard;
    }
}

