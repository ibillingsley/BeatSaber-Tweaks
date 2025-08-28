using HarmonyLib;
using UnityEngine;

namespace IzaTweaks.Patches
{
	// Fix 1.40.0+ HSV bug
	// https://github.com/Meivyn/BeatSaberBugs/issues/26

	[HarmonyPatch(typeof(FlyingScoreSpawner), nameof(FlyingScoreSpawner.SpawnFlyingScoreNextFrame))]
	static class SpawnFlyingScore
	{
		static bool Prefix(FlyingScoreSpawner __instance, IReadonlyCutScoreBuffer cutScoreBuffer, Color color)
		{
			__instance.SpawnFlyingScore(cutScoreBuffer, color);
			return false;
		}
	}
}
