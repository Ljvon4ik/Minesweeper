using CobeBase.Gameplay.Tiles;
using CobeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CobeBase.Gameplay.Factories
{
    public class GameTileContentFactory
    {
        private readonly AssetProvider _assetProvider;
        private readonly string EmptyTile = AssetPath.EmptyTile;
        private readonly string BombTile = AssetPath.BombTile;
        private readonly string FlagTile = AssetPath.FlagTile;
        private readonly string BombIndicatorTile = AssetPath.BombIndicatorTile;
        private readonly string ClosedTile = AssetPath.ClosedTile;

        public GameTileContentFactory(AssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameTileContent Get(GameTileContentType type, GameTile gameTile)
        {
            Vector3 pos = gameTile.transform.position;
            Transform parent = gameTile.transform;
            return type switch
            {
                GameTileContentType.Empty => _assetProvider.Instantiate<GameTileContent>(EmptyTile, pos, parent),
                GameTileContentType.Bomb => _assetProvider.Instantiate<GameTileContent>(BombTile, pos, parent),
                GameTileContentType.Flag => _assetProvider.Instantiate<GameTileContent>(FlagTile, pos, parent),
                GameTileContentType.BombIndicator => _assetProvider.Instantiate<GameTileContent>(BombIndicatorTile, pos, parent),
                GameTileContentType.Closed => _assetProvider.Instantiate<GameTileContent>(ClosedTile, pos, parent),
                _ => null,
            };
        }
    }
}
