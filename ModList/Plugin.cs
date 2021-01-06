﻿using System.Reflection;
using IPA.Loader;
using IPA.Logging;
using IPA.ModList.BeatSaber.Installers;
using SiraUtil.Zenject;

namespace IPA.ModList.BeatSaber
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Logger? Logger { get; private set; }

        [Init]
        public void Init(Logger log, IPA.Config.Config config, PluginMetadata pluginMetadata, Zenjector zenject)
        {
            Logger = log;

            zenject.OnApp<AppInstaller>().WithParameters(log, config, pluginMetadata.Name ?? Assembly.GetExecutingAssembly().GetName().Name);
            zenject.OnMenu<Installers.MenuInstaller>();
        }

        [OnEnable, OnDisable]
        public void OnStateChanged()
        {
            // Zenject is poggers
        }
    }
}