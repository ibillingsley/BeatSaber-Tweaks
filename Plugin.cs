using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Loader;
using IPA.Logging;
using IzaTweaks.Installers;
using SiraUtil.Zenject;

namespace IzaTweaks
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    internal class Plugin
    {
        internal static Logger Log { get; private set; }
        internal static PluginConfig Config { get; private set; }
        internal static PluginConfig Default = new PluginConfig();

        // Methods with [Init] are called when the plugin is first loaded by IPA.
        // All the parameters are provided by IPA and are optional.
        // The constructor is called before any method with [Init]. Only use [Init] with one constructor.

        [Init]
        public Plugin(Logger logger, Config config, PluginMetadata pluginMetadata, Zenjector zenject)
        {
            Log = logger;
            Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
            Config = config.Generated<PluginConfig>(false);
            zenject.UseLogger(logger);
            zenject.Install<MenuInstaller>(Location.Menu);
            zenject.Install<GameInstaller>(Location.GameCore);
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");
        }
    }
}
