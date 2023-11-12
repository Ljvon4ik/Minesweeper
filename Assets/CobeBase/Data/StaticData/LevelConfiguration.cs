using System;
using UnityEngine;

namespace CobeBase.Data.StaticData
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Data/Level Config")]
    public class LevelConfiguration : ScriptableObject
    {
        public LevelType Type;
        [SerializeField] private int _widthBoard;
        [SerializeField] private int _heightBoard;
        [SerializeField] private int _bombsCount;

        public string LevelName => Enum.GetName(typeof(LevelType), Type);
        public int BombsCount => _bombsCount;
        public int WidthBoard => _widthBoard;
        public int HeightBoard => _heightBoard;
    }
}

