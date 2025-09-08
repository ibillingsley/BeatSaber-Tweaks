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

        [UIValue("NoteColorForceOverride")]
        public bool NoteColorForceOverride
        {
            get => Plugin.Config.NoteColorForceOverride;
            set => Plugin.Config.NoteColorForceOverride = value;
        }

        [UIValue("ReeSabersNotesColorShift")]
        public bool ReeSabersNotesColorShift
        {
            get => Plugin.Config.ReeSabersNotesColorShift;
            set => Plugin.Config.ReeSabersNotesColorShift = value;
        }

        [UIValue("FixCutScoreText")]
        public bool FixCutScoreText
        {
            get => Plugin.Config.FixCutScoreText;
            set => Plugin.Config.FixCutScoreText = value;
        }

        [UIValue("ScorePercentFontSize")]
        public float ScorePercentFontSize
        {
            get => Plugin.Config.ScorePercentFontSize;
            set => Plugin.Config.ScorePercentFontSize = value;
        }

        [UIValue("RankFontSize")]
        public float RankFontSize
        {
            get => Plugin.Config.RankFontSize;
            set => Plugin.Config.RankFontSize = value;
        }
    }
}
