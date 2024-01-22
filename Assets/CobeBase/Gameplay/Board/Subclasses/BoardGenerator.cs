using CobeBase.Gameplay.Factories;
using CobeBase.Gameplay.Tiles;
using CobeBase.Infrastructure.AssetManagement;
using CobeBase.Services.CurrentLevelProvider;
using System;
using UnityEngine;
using Zenject;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class BoardGenerator : MonoBehaviour
    {
        private TileMatrix _tileMatrix;
        public TileMatrix TileMatrix
        {
            get
            {
                if (_tileMatrix == null)
                    GenerateBoard();

                return _tileMatrix;
            }
        }


        private const string gameTilePath = AssetPath.GameTile;
        private byte _width;
        private byte _height;
        private GameTileContentFactory _tilesFactory;
        private bool _isInit;
        private const string InitError = "To use the GenerateBoard method, you must initialize the BoardGenerator class by calling the Construct() method.";

        [Inject]
        public void Construct(ICurrentLevelProvider currentLevelProvider, GameTileContentFactory gameTileContentFactory)
        {
            _width = currentLevelProvider.CurrentLevelConfiguration.WidthBoard;
            _height = currentLevelProvider.CurrentLevelConfiguration.HeightBoard;
            _tilesFactory = gameTileContentFactory;
            _isInit = true;
        }

        public void GenerateBoard()
        {
            if (!_isInit)
                throw new InvalidOperationException(InitError);

            GameTile[,] tiles = new GameTile[_width, _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Vector3 pos = new(x, y, transform.position.z);
                    GameTile tile = AssetProvider.Instantiate<GameTile>(gameTilePath, pos, this.transform);
                    tile.Init(_tilesFactory);
                    tiles[x, y] = tile;
                }
            }

            _tileMatrix = new TileMatrix(tiles);
        }
    }
}
