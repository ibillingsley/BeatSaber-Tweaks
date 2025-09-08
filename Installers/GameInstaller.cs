using IPA.Loader;
using IzaTweaks.Patches;
using Zenject;

namespace IzaTweaks.Installers
{
    internal class GameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GamePatches>().AsSingle();

#if REESABERS
            if (PluginManager.GetPluginFromId("ReeSabers") != null)
                Container.BindInterfacesTo<ReeSabersPatches>().AsSingle();
#endif
        }
    }
}
