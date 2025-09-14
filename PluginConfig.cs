namespace IzaTweaks
{
    public class PluginConfig
    {
        public bool DisablePlayerPlatformBorder { get; set; } = false;
        public float WallBloom { get; set; } = 1.0f;
        public float ScorePercentFontSize { get; set; } = 12.0f;
        public float RankFontSize { get; set; } = 33.0f;
        public bool ClearFilterOnSongRequest { get; set; } = false;
        public bool NoteColorForceOverride { get; set; } = false;
        public bool ReeSabersNotesColorShift { get; set; } = false;
        public bool FixCutScoreText { get; set; } = false;
    }
}
