using IzaTweaks.Patches;
using Zenject;

namespace IzaTweaks.Installers
{
    internal class GameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSceneInit>().AsSingle();
        }
    }
}
