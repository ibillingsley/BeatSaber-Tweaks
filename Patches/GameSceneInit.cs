using UnityEngine;
using Zenject;

namespace IzaTweaks.Patches
{
	// Disable the glowing border on the player platform

	class GameSceneInit : IInitializable
	{
		public void Initialize()
		{
			GameObject.Find("PlayersPlace/RectangleFakeGlow")?.SetActive(false);
		}
	}
}
