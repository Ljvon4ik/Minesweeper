using UnityEngine;

namespace CobeBase.Gameplay.Tiles
{
    public class GameTileContent : MonoBehaviour
    {
        [SerializeField]
        private GameTileContentType _type;
        public GameTileContentType Type => _type;

        public void Remove()
        {
            Destroy(gameObject);
        }
    }
}
