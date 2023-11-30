using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Factories;
using CobeBase.Gameplay.Tiles;
using CobeBase.Infrastructure.AssetManagement;
using CobeBase.Services.InputServices;
using System.Collections.Generic;
using UnityEngine;

namespace CobeBase.Gameplay
{
    public class GameBoard : MonoBehaviour
    {
        private AssetProvider _assetProvider;
        private byte _width;
        private byte _height;
        private byte _bombsCount;

        private GameTile[,] _tiles;

        private IInputService _inputService;

        private bool _isFirstTileOpen;

        private GameTileContentFactory _contentFactory;

        public void Init(LevelConfiguration levelConfiguration, 
            AssetProvider assetProvider, IInputService inputService,
            GameTileContentFactory gameTileContentFactory)
        {
            _contentFactory = gameTileContentFactory;
            _assetProvider = assetProvider;
            _width = levelConfiguration.WidthBoard;
            _height = levelConfiguration.HeightBoard;
            _bombsCount = levelConfiguration.BombsCount;
            _tiles = new GameTile[_width, _height];

            _inputService = inputService;
            _inputService.TileClicked += TileCliked;

            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    string path = AssetPath.GameTile;
                    Vector3 pos = new(x, y, 0);
                    GameTile tile = _assetProvider.Instantiate<GameTile>(path, pos, this.transform);
                    tile.Init(_contentFactory);
                    _tiles[x, y] = tile;
                }
            }
        }

        private void InitializeGameTiles(GameTile tile)
        {
            InitBombTiles(tile);
            InitBombIndicatorTiles();
            _isFirstTileOpen = true;
        }

        private void InitBombIndicatorTiles()
        {
            GameTileType bombType = GameTileType.Bomb;

            foreach (GameTile tile in _tiles)
            {
                if (tile.Type == bombType)
                    continue;

                byte adjacentBombs = 0;

                foreach (GameTile adjacentTile in GetAdjacentTiles(tile))
                {
                    if (adjacentTile.Type == bombType)
                        adjacentBombs++;
                }

                if (adjacentBombs > 0)
                    tile.AdjacentBombCount = adjacentBombs;
            }
        }
        private void InitBombTiles(GameTile tile)
        {
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
        private void TileCliked(GameTile tile)
        {
            if (!_isFirstTileOpen)
                InitializeGameTiles(tile);

            if (tile.IsOpened)
                return;

            tile.IsOpened = true;

            Debug.Log(tile.Type);
        }

        private GameTile GetTile(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                return _tiles[x, y];
            return null;
        }
        private List<GameTile> GetAdjacentTiles(GameTile tile)
        {
            byte xPos = (byte)tile.transform.position.x;
            byte yPos = (byte)tile.transform.position.y;

            List<GameTile> adjacentTiles = new();
            for (int x = xPos - 1; x <= xPos + 1; x++)
            {
                for (int y = yPos - 1; y <= yPos + 1; y++)
                {
                    if (x >= 0 && x < _width && y >= 0 && y < _height && !(x == xPos && y == yPos))
                        adjacentTiles.Add(_tiles[x, y]);
                }
            }
            return adjacentTiles;
        }

        private void OnDestroy()
        {
            _inputService.TileClicked -= TileCliked;
        }

    }
}
