using CobeBase.Data.StaticData;
using CobeBase.Gameplay.Factories;
using CobeBase.Gameplay.Tiles;
using CobeBase.Infrastructure.AssetManagement;
using CobeBase.Services.CurrentLevelProvider;
using UnityEngine;
using Zenject;

namespace CobeBase.Gameplay.Board.Subclasses
{
    public class BoardGenerator : MonoBehaviour
    {
        private GameTile[,] _tiles;
        public GameTile[,] ArrayOfTiles 
        { get 
            {
                if (_tiles == null)
                    GenerateBoard();

                return _tiles;
            } 
        }

        private readonly string gameTilePath = AssetPath.GameTile;
        private byte _width;
        private byte _height;
        private GameTileContentFactory _tilesFactory;

        private bool _isInit;
        private string _initError = "To use the board generation method, you must initialize the class BoardGenerator";

        [Inject]
        public void Construct(ICurrentLevelProvider currentLevelProvider, GameTileContentFactory gameTileContentFactory)
        {
            LevelConfiguration configuration = currentLevelProvider.CurrentLevelConfiguration;
            _width = configuration.WidthBoard;
            _height = configuration.HeightBoard;
            _tilesFactory = gameTileContentFactory;
            _isInit = true;
        }

        public void GenerateBoard()
        {
            if (!_isInit)
                throw new System.Exception(_initError);

            _tiles = new GameTile[_width, _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Vector3 pos = new(x, y, 0);
                    GameTile tile = AssetProvider.Instantiate<GameTile>(gameTilePath, pos, this.transform);
                    tile.Init(_tilesFactory);
                    _tiles[x, y] = tile;
                }
            }
        }
    }
}
