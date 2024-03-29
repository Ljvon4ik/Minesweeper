﻿using CobeBase.Gameplay.Tiles;
using CobeBase.Infrastructure.AssetManagement;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace CobeBase.Gameplay.Factories
{
    public class GameTileContentFactory
    {
        private readonly string EmptyTile = AssetPath.EmptyTile;
        private readonly string BombTile = AssetPath.BombTile;
        private readonly string FlagTile = AssetPath.FlagTile;
        private readonly string BombIndicatorTile = AssetPath.BombIndicatorTile;
        private readonly string ClosedTile = AssetPath.ClosedTile;

        public GameTileContent Get(GameTileContentType type, GameTile gameTile)
        {
            Vector3 pos = gameTile.transform.position;
            Transform parent = gameTile.transform;
            return type switch
            {
                GameTileContentType.Empty => AssetProvider.Instantiate<GameTileContent>(EmptyTile, pos, parent),
                GameTileContentType.Bomb => AssetProvider.Instantiate<GameTileContent>(BombTile, pos, parent),
                GameTileContentType.Flag => AssetProvider.Instantiate<GameTileContent>(FlagTile, pos, parent),
                GameTileContentType.BombIndicator => GetBombIndicator(gameTile),
                GameTileContentType.Closed => AssetProvider.Instantiate<GameTileContent>(ClosedTile, pos, parent),
                _ => null,
            };
        }

        private GameTileContent GetBombIndicator(GameTile gameTile)
        {
            BombIndicatorContent content = AssetProvider.Instantiate<BombIndicatorContent>(BombIndicatorTile, gameTile.transform.position, gameTile.transform);
            content.SetValue(gameTile.AdjacentBombCount);
            return content;
        }
    }
}
