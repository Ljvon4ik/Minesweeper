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
        private bool _isOpened;
        private bool _isFlag;
        private byte _adjacentBombCount;

        public bool IsOpened
        {
            get => _isOpened;
            set
            {
                if (IsFlag)
                    return;

                _isOpened = value;

                if (value)
                {
                    if (this.Type == GameTileType.Empty)
                        SetContent(_contentFactory.Get(GameTileContentType.Empty, this));

                    if (this.Type == GameTileType.Bomb)
                        SetContent(_contentFactory.Get(GameTileContentType.Bomb, this));

                    if (this.Type == GameTileType.BombIndicator)
                        SetContent(_contentFactory.Get(GameTileContentType.BombIndicator, this));
                }
            }
        }
        public bool IsFlag
        {
            get => _isFlag;
            set 
            {
                if (IsOpened)
                    return;

                _isFlag = value;

                if (value)
                {
                    SetContent(_contentFactory.Get(GameTileContentType.Flag, this));
                }
                else
                {
                    SetContent(_contentFactory.Get(GameTileContentType.Closed, this));
                }
            }
        }
        public byte AdjacentBombCount
        {
            get => _adjacentBombCount;
            set
            {
                if (value < 0 || value > 8)
                    throw new ArgumentException("Error: Cannot assign a value greater than 8 or less than 0. Please provide a valid value within the specified range.");
                
                _adjacentBombCount = value;

                if (value > 0)
                    this.Type = GameTileType.BombIndicator;
            }
        }
        public void Init(GameTileContentFactory contentFactory)
        {
            _contentFactory = contentFactory;
            this.Type = GameTileType.Empty;
            SetContent(_contentFactory.Get(GameTileContentType.Closed, this));
        }
        private void SetContent(GameTileContent content)
        {
            if (_content != null)
                _content.Remove();

            _content = content;
        }

    }
}
