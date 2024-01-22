using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Tiles;
using CobeBase.Services.CurrentLevelProvider;
using UnityEngine;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class BombInstaller : InitializableBaseSubclass
    {
        private readonly byte _width;
        private readonly byte _height;
        private readonly byte _bombsCount;

        private const byte BombRadius = 1;

        public BombInstaller(ICurrentLevelProvider currentLevelProvider, BoardGenerator boardGenerator)
            : base(boardGenerator)
        {
            LevelConfiguration configuration = currentLevelProvider.CurrentLevelConfiguration;
            _width = configuration.WidthBoard;
            _height = configuration.HeightBoard;
            _bombsCount = configuration.BombsCount;
        }

        public void PlaceBombs(GameTile tile)
        {
            int xPos = (int)tile.transform.position.x;
            int yPos = (int)tile.transform.position.y;

            GameTileType bombType = GameTileType.Bomb;

            for (int i = 0; i < _bombsCount; i++)
            {
                Vector2Int bombPosition = GenerateRandomPosition();

                while (IsWithinRadius(bombPosition, xPos, yPos, BombRadius) || IsDuplicateBomb(bombPosition))
                {
                    bombPosition = GenerateRandomPosition();
                }

                GameTile gameTile = GetTile(bombPosition.x, bombPosition.y);
                gameTile.Type = bombType;
            }
        }

        private Vector2Int GenerateRandomPosition()
        {
            int x = Random.Range(0, _width);
            int y = Random.Range(0, _height);
            return new Vector2Int(x, y);
        }

        private bool IsWithinRadius(Vector2Int position, int centerX, int centerY, int radius)
        {
            return Mathf.Abs(position.x - centerX) <= radius && Mathf.Abs(position.y - centerY) <= radius;
        }

        private bool IsDuplicateBomb(Vector2Int position)
        {
            GameTile gameTile = GetTile(position.x, position.y);
            return gameTile.Type == GameTileType.Bomb;
        }
        private GameTile GetTile(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                return _boardGenerator.TileMatrix.GetTileMatrix()[x, y];
            return null;
        }
    }
}
