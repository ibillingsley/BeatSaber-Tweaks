using System.Reflection;
using HarmonyLib;
using IPA;
using IPA.Loader;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace IzaTweaks
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    internal class Plugin
    {
        internal static IPALogger Log { get; private set; }
        internal static Harmony Harmony { get; private set; }

        // Methods with [Init] are called when the plugin is first loaded by IPA.
        // All the parameters are provided by IPA and are optional.
        // The constructor is called before any method with [Init]. Only use [Init] with one constructor.

        [Init]
        public Plugin(IPALogger ipaLogger, PluginMetadata pluginMetadata)
        {
            Log = ipaLogger;

            Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
            Harmony = new Harmony("IzaTweaks");
            Harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");
            Harmony.UnpatchSelf();
        }
    }
}
