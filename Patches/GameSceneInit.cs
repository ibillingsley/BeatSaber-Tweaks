using UnityEngine;
using Zenject;

namespace IzaTweaks.Patches
{
    // Disable the glowing border on the player platform

    class GameSceneInit : IInitializable
    {
        readonly CoreGameHUDController _gameHUDController;

        public GameSceneInit(CoreGameHUDController gameHUDController)
        {
            _gameHUDController = gameHUDController;
        }

        public void Initialize()
        {
            if (Plugin.Config.DisablePlayerPlatformBorder)
                GameObject.Find("PlayersPlace/RectangleFakeGlow")?.SetActive(false);

            if (Plugin.Config.RankPercentFontSize != Plugin.Default.RankPercentFontSize || Plugin.Config.RankLetterFontSize != Plugin.Default.RankLetterFontSize)
            {
                var immediateRankUIPanel = _gameHUDController.GetComponentInChildren<ImmediateRankUIPanel>();
                if (immediateRankUIPanel != null)
                {
                    immediateRankUIPanel._relativeScoreText.fontSize = Plugin.Config.RankPercentFontSize;
                    immediateRankUIPanel._relativeScoreText.enableWordWrapping = false;

                    immediateRankUIPanel._rankText.fontSize = Plugin.Config.RankLetterFontSize;
                    immediateRankUIPanel._rankText.enableWordWrapping = false;
                }
            }
        }
    }
}
