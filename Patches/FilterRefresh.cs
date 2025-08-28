using System.Diagnostics;
using System.Linq;
using HarmonyLib;

namespace IzaTweaks.Patches
{
	// Clear BetterSongList filter when selecting a BeatSaberPlus song request

	[HarmonyPatch(typeof(LevelSearchViewController), nameof(LevelSearchViewController.Refresh), new[] { typeof(LevelFilter) }, new[] { ArgumentType.Ref })]
	static class FilterRefresh
	{
		static void Prefix(LevelSearchViewController __instance)
		{
			// From https://github.com/kinsi55/BeatSaber_BetterSongList
			var x = new StackTrace().GetFrames()?.DefaultIfEmpty(null).ElementAtOrDefault(2)?.GetMethod().DeclaringType?.Assembly.GetName().Name;
			if (x == "Main")
				return;

			__instance.ResetAllFilterSettings(false);
		}
	}
}
