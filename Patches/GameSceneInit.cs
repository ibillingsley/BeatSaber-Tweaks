using UnityEngine;
using Zenject;

namespace IzaTweaks.Patches
{
    // Disable the glowing border on the player platform

    class GameSceneInit : IInitializable
    {
        public void Initialize()
        {
            if (Plugin.Config.DisablePlayerPlatformBorder)
                GameObject.Find("PlayersPlace/RectangleFakeGlow")?.SetActive(false);
        }
    }
}
