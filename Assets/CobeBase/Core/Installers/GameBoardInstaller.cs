using CobeBase.Gameplay.Board;
using CobeBase.Gameplay.Board.Subclasses;
using CobeBase.Gameplay.Factories;
using CobeBase.Infrastructure.AssetManagement;
using Zenject;

namespace CobeBase.Core.Installers
{
    public class GameBoardInstaller : Installer<GameBoardInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameBoard>().AsSingle();
            Container.Bind<BoardGenerator>().FromComponentInNewPrefabResource(AssetPath.GameBoard).AsSingle();
            Container.Bind<BombInstaller>().AsSingle();
            Container.Bind<BombCluesInstaller>().AsSingle();
            Container.Bind<Filler>().AsSingle();
            Container.Bind<GameTileContentFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BoardInputHandler>().AsSingle().NonLazy();
            Container.Bind<TileFlagManager>().AsSingle();
            Container.Bind<AutoDigger>().AsSingle();
        }
    }
}
