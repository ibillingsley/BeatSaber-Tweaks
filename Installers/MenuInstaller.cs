using IPA.Loader;
using IzaTweaks.Patches;
using IzaTweaks.UI;
using Zenject;

namespace IzaTweaks.Installers
{
    internal class MenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MenuPatches>().AsSingle();
            Container.BindInterfacesTo<SettingsMenu>().AsSingle();

#if REESABERS
            if (PluginManager.GetPluginFromId("ReeSabers") != null)
                Container.BindInterfacesTo<ReeSabersPatches>().AsSingle();
#endif
        }
    }
}
