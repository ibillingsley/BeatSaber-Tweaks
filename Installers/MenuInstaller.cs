using IzaTweaks.UI;
using Zenject;

namespace IzaTweaks.Installers
{
    internal class MenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SettingsMenu>().AsSingle();
        }
    }
}
