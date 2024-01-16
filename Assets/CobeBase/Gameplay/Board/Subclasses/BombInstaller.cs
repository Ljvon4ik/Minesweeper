using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Tiles;
using CobeBase.Services.CurrentLevelProvider;
using UnityEngine;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class BombInstaller : InitializableBaseSubclass
    {
        private byte _width;
        private byte _height;
        private byte _bombsCount;

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
            ArrayOfTiles = _boardGenerator.ArrayOfTiles;

            int xPos = (int)tile.transform.position.x;
            int yPos = (int)tile.transform.position.y;

            GameTileType bombType = GameTileType.Bomb;

            for (int i = 0; i < _bombsCount; i++)
            {
                int x = Random.Range(0, _width);
                int y = Random.Range(0, _height);

                if ((x >= xPos - 1 && x <= xPos + 1) && (y >= yPos - 1 && y <= yPos + 1))
                {
                    i--;
                    continue;
                }

                GameTile gameTile = GetTile(x, y);

                if (gameTile.Type == bombType)
                    i--;
                else
                    gameTile.Type = bombType;
            }

        }

        private GameTile GetTile(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                return ArrayOfTiles[x, y];
            return null;
        }
    }
}
