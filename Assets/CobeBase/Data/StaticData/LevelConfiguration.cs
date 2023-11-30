using System;
using UnityEngine;

namespace CobeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Data/Level Config")]
    public class LevelConfiguration : ScriptableObject
    {
        public LevelType Type;
        [SerializeField] private byte _widthBoard;
        [SerializeField] private byte _heightBoard;
        [SerializeField] private byte _bombsCount;

        public string LevelName => Enum.GetName(typeof(LevelType), Type);
        public byte BombsCount => _bombsCount;
        public byte WidthBoard => _widthBoard;
        public byte HeightBoard => _heightBoard;
    }
}

