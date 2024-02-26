using System;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace RabbitRollSCPSL.RemoteCard
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
            
            Log.Warn("RabbitRollSCPSL.RemoteCard is enabled!");
            
            // Log.Warn($"I correctly read the string config, its value is: {Config.String}");
            // Log.Warn($"I correctly read the int config, its value is: {Config.Int}");
            // Log.Warn($"I correctly read the float config, its value is: {Config.Float}");

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
            Exiled.Events.Handlers.Player.InteractingDoor += _eventWeaponHandler.OnDoorInteracting;
            Exiled.Events.Handlers.Player.ActivatingWarheadPanel += _eventWeaponHandler.OnActivatingWarheadPanel;
            Exiled.Events.Handlers.Player.UnlockingGenerator += _eventWeaponHandler.OnUnlockingGenerator;
            Exiled.Events.Handlers.Player.InteractingLocker += _eventWeaponHandler.OnInteractingLocker;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            if (_eventWeaponHandler == null) return;
            Exiled.Events.Handlers.Player.ActivatingWarheadPanel -= _eventWeaponHandler.OnActivatingWarheadPanel;
            Exiled.Events.Handlers.Player.UnlockingGenerator -= _eventWeaponHandler.OnUnlockingGenerator;
            Exiled.Events.Handlers.Player.InteractingLocker -= _eventWeaponHandler.OnInteractingLocker;
            _eventWeaponHandler = null;
        }
    
    }
}