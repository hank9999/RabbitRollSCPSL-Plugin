using System;
using System.IO;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace RabbitRollSCPSL.LevelSystem
{
    public class PluginMain : Plugin<Config>
    {
        public override Version RequiredExiledVersion => new Version(8, 0, 0);
    
        private PluginMain()
        {
        }

        /// <summary>
        /// Gets the only existing instance of this plugin.
        /// </summary>
        public static PluginMain Instance { get; } = new PluginMain();

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Last;

        private EventHandlers _eventWeaponHandler;
    
        /// <inheritdoc/>
        public override void OnEnabled()
        {
            RegisterEvents();
            
            Log.Warn("RabbitRollSCPSL.LevelSystem is enabled!");
            
            // Log.Warn($"I correctly read the string config, its value is: {Config.String}");
            // Log.Warn($"I correctly read the int config, its value is: {Config.Int}");
            // Log.Warn($"I correctly read the float config, its value is: {Config.Float}");
            Log.Info($"{Paths.Configs}, {Paths.Exiled}, {Paths.Config}, {Paths.ServerConfig}");
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        /// <summary>
        /// Registers the plugin events.
        /// </summary>
        private void RegisterEvents()
        {
            _eventWeaponHandler = new EventHandlers();
            Exiled.Events.Handlers.Player.Died += _eventWeaponHandler.OnDied;
            Exiled.Events.Handlers.Player.Escaping += _eventWeaponHandler.OnEscaping;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            if (_eventWeaponHandler == null) return;
            Exiled.Events.Handlers.Player.Died -= _eventWeaponHandler.OnDied;
            Exiled.Events.Handlers.Player.Escaping -= _eventWeaponHandler.OnEscaping;

            _eventWeaponHandler = null;
        }
    
    }
}