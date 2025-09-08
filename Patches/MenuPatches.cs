using System.Collections.Generic;
using System.Linq;
using BeatSaberMarkupLanguage.Components.Settings;
using BeatSaberMarkupLanguage.GameplaySetup;
using HarmonyLib;
using IPA.Loader;
using IPA.Utilities;
using SiraUtil.Affinity;
using SongCore.UI;
using UnityEngine;

namespace IzaTweaks.Patches
{
    public class MenuPatches : IAffinity
    {
        readonly ColorsUI colorsUI;
        readonly GameplaySetup gameplaySetup;

        public MenuPatches(ColorsUI _colorsUI, GameplaySetup _gameplaySetup)
        {
            colorsUI = _colorsUI;
            gameplaySetup = _gameplaySetup;
        }

        // Clear BetterSongList filter when selecting a BeatSaberPlus song request

        [AffinityPrefix]
        [AffinityPatch(typeof(LevelSearchViewController), nameof(LevelSearchViewController.Refresh), AffinityMethodType.Normal, new[] { AffinityArgumentType.Ref }, typeof(LevelFilter))]
        public void ClearFilterOnSongRequest(LevelSearchViewController __instance, LevelFilter filter)
        {
            if (Plugin.Config.ClearFilterOnSongRequest && filter.limitIds?.Length == 1)
                __instance.ResetAllFilterSettings(false);
        }

        // Auto toggle SongCore and Chroma note colors when "override default colors" is toggled

        [AffinityPostfix]
        [AffinityPatch(typeof(ColorsOverrideSettingsPanelController), "HandleOverrideColorsToggleValueChanged")]
        public void NoteColorOverrideToggle(bool isOn)
        {
            if (!Plugin.Config.NoteColorForceOverride) return;

            // Toggle SongCore setting "Allow Custom Song Note Colors"
            colorsUI.NoteColors = !isOn;
            colorsUI.InvokeMethod<object, ColorsUI>("NotifyPropertyChanged", "NoteColors"); // Update toggle UI

            var chroma = PluginManager.GetPluginFromId("Chroma");
            if (chroma != null)
            {
                // Toggle Chroma setting "Disable Note Coloring"
                var settingsType = chroma.Assembly.GetTypes().First(t => t.Name == "ChromaSettableSettings");
                var noteColoringDisabledSetting = Traverse.Create(settingsType).Property("NoteColoringDisabledSetting").GetValue();
                Traverse.Create(noteColoringDisabledSetting).Property("Value").SetValue(isOn);

                // Update toggle UI
                var menus = Traverse.Create(gameplaySetup).Field("menus").GetValue<IEnumerable<object>>();
                var menu = menus.FirstOrDefault(m => Traverse.Create(m).Property("Name").GetValue<string>() == "Chroma");
                if (menu != null)
                {
                    var toggles = Traverse.Create(menu).Field("tabObject").GetValue<GameObject>().GetComponentsInChildren<ToggleSetting>();
                    var toggle = toggles.FirstOrDefault(t => t.AssociatedValue.MemberName == "NoteColoringDisabled");
                    if (toggle != null)
                        toggle.Value = isOn;
                }
            }
        }
    }
}
