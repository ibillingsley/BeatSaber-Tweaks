using HarmonyLib;

namespace IzaTweaks.Patches
{
    // Disable wall outline bloom

    [HarmonyPatch(typeof(ParametricBoxFrameController), nameof(ParametricBoxFrameController.Refresh))]
    static class WallBloom
    {
        static void Prefix(ParametricBoxFrameController __instance)
        {
            if (Plugin.Config.DisableWallBloom)
                __instance.color.a *= 0;
        }
    }
}
