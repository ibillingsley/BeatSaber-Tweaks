using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using Zenject;

namespace IzaTweaks.UI
{
    class SettingsMenu : IInitializable
    {
        public void Initialize()
        {
            BSMLSettings.Instance.AddSettingsMenu("Iza's Tweaks", "IzaTweaks.UI.SettingsMenu.bsml", this);
        }

        [UIValue("DisablePlayerPlatformBorder")]
        public bool DisablePlayerPlatformBorder
        {
            get => Plugin.Config.DisablePlayerPlatformBorder;
            set => Plugin.Config.DisablePlayerPlatformBorder = value;
        }

        [UIValue("DisableWallBloom")]
        public bool DisableWallBloom
        {
            get => Plugin.Config.DisableWallBloom;
            set => Plugin.Config.DisableWallBloom = value;
        }

        [UIValue("ClearFilterOnSongRequest")]
        public bool ClearFilterOnSongRequest
        {
            get => Plugin.Config.ClearFilterOnSongRequest;
            set => Plugin.Config.ClearFilterOnSongRequest = value;
        }

        [UIValue("FixHSV")]
        public bool FixHSV
        {
            get => Plugin.Config.FixHSV;
            set => Plugin.Config.FixHSV = value;
        }
    }
}
