using System.Collections.Generic;
using UnityEngine;

namespace CobeBase.Data.StaticData
{
    //[CreateAssetMenu(fileName = "LevelsDatabase", menuName = "Data/Levels Database")]
    public class LevelsDatabase : ScriptableObject
    {
        [SerializeField] private LevelConfiguration[] _levels;

        private Dictionary<LevelType, LevelConfiguration> _levelsCached = new Dictionary<LevelType, LevelConfiguration>();

        private void Init()
        {
            _levelsCached.Clear();

            foreach (var level in _levels)
            {
                _levelsCached.Add(level.Type, level);
            }
        }

        public LevelConfiguration GetInfo(LevelType type)
        {
            if (_levelsCached.Count == 0)
                Init();

            if (_levelsCached.TryGetValue(type, out LevelConfiguration level))
            {
                return level;
            }

            return null;
        }
    }
}

