using SiraUtil.Affinity;

namespace IzaTweaks.Patches
{
    public class MenuPatches : IAffinity
    {
        // Clear BetterSongList filter when selecting a BeatSaberPlus song request

        [AffinityPrefix]
        [AffinityPatch(typeof(LevelSearchViewController), nameof(LevelSearchViewController.Refresh), AffinityMethodType.Normal, new[] { AffinityArgumentType.Ref }, typeof(LevelFilter))]
        public void ClearFilterOnSongRequest(LevelSearchViewController __instance, LevelFilter filter)
        {
            if (Plugin.Config.ClearFilterOnSongRequest && filter.limitIds?.Length == 1)
                __instance.ResetAllFilterSettings(false);
        }
    }
}
