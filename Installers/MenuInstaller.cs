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
        }
    }
}
