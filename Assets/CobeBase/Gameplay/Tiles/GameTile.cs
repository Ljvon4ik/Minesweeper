using CobeBase.Gameplay.Factories;
using System;
using UnityEngine;

namespace CobeBase.Gameplay.Tiles
{
    public class GameTile : MonoBehaviour
    {
        public GameTileType Type { get; set; }

        private GameTileContentFactory _contentFactory;

        private GameTileContent _content;
        private GameTileContent Content
        {
            set
            {
                if (_content != null)
                    _content.Remove();

                _content = value;
            }
        }

        private bool _isOpened;
        public bool IsOpened
        {
            get => _isOpened;
            set
            {
                _isOpened = value;

                if (value == true)
                {
                    if (this.Type == GameTileType.Empty)
                        Content = _contentFactory.Get(GameTileContentType.Empty, this);

                    if (this.Type == GameTileType.Bomb)
                        Content = _contentFactory.Get(GameTileContentType.Bomb, this);

                    if (this.Type == GameTileType.BombIndicator)
                        Content = _contentFactory.Get(GameTileContentType.BombIndicator, this);

                    if (this.Type == GameTileType.Flag)
                        Content = _contentFactory.Get(GameTileContentType.Flag, this);
                }
            }
        }

        private byte _adjacentBombCount;
        public byte AdjacentBombCount
        {
            get => _adjacentBombCount;
            set
            {
                if (value < 0 || value > 8)
                    throw new Exception("Error: Cannot assign a value greater than 8 or less than 0. Please provide a valid value within the specified range.");

                if (value > 0)
                    this.Type = GameTileType.BombIndicator;

                _adjacentBombCount = value;
            }
        }
        public void Init(GameTileContentFactory contentFactory)
        {
            _contentFactory = contentFactory;
            this.Type = GameTileType.Empty;
            Content = _contentFactory.Get(GameTileContentType.Closed, this);
        }
    }
}
