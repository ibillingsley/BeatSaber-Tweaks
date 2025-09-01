using SiraUtil.Affinity;
using UnityEngine;

namespace IzaTweaks.Patches
{
    public class GamePatches : IAffinity
    {
        public GamePatches(CoreGameHUDController gameHUDController)
        {
            // Disable the glowing border on the player platform
            if (Plugin.Config.DisablePlayerPlatformBorder)
                GameObject.Find("PlayersPlace/RectangleFakeGlow")?.SetActive(false);

            // HUD font sizes
            if (Plugin.Config.ScorePercentFontSize != Plugin.Default.ScorePercentFontSize || Plugin.Config.RankFontSize != Plugin.Default.RankFontSize)
            {
                var immediateRankUIPanel = gameHUDController.GetComponentInChildren<ImmediateRankUIPanel>();
                if (immediateRankUIPanel != null)
                {
                    immediateRankUIPanel._relativeScoreText.fontSize = Plugin.Config.ScorePercentFontSize;
                    immediateRankUIPanel._relativeScoreText.enableWordWrapping = false;

                    immediateRankUIPanel._rankText.fontSize = Plugin.Config.RankFontSize;
                    immediateRankUIPanel._rankText.enableWordWrapping = false;
                }
            }
        }

        // Disable wall outline bloom

        [AffinityPrefix]
        [AffinityPatch(typeof(ParametricBoxFrameController), nameof(ParametricBoxFrameController.Refresh))]
        public void DisableWallBloom(ParametricBoxFrameController __instance)
        {
            if (Plugin.Config.DisableWallBloom)
                __instance.color.a = 0;
        }

        // Fix 1.40.0+ HSV bug
        // https://github.com/Meivyn/BeatSaberBugs/issues/26

        [AffinityPrefix]
        [AffinityPatch(typeof(FlyingScoreSpawner), nameof(FlyingScoreSpawner.SpawnFlyingScoreNextFrame))]
        public bool FixCutScoreText(FlyingScoreSpawner __instance, IReadonlyCutScoreBuffer cutScoreBuffer, Color color)
        {
            if (!Plugin.Config.FixCutScoreText) return true;

            __instance.SpawnFlyingScore(cutScoreBuffer, color);
            return false;
        }
    }
}
