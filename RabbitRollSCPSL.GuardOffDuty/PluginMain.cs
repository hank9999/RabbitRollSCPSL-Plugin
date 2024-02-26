using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;

namespace RabbitRollSCPSL.GuardOffDuty
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

        private CoroutineHandle? _checkPositionCoroutine;
    
        /// <inheritdoc/>
        public override void OnEnabled()
        {
            
            Log.Warn("RabbitRollSCPSL.GuardOffDuty is enabled!");
            
            // Log.Warn($"I correctly read the string config, its value is: {Config.String}");
            // Log.Warn($"I correctly read the int config, its value is: {Config.Int}");
            // Log.Warn($"I correctly read the float config, its value is: {Config.Float}");
            _checkPositionCoroutine = Timing.RunCoroutine(Coroutines.CheckPlayerPostionCoroutine());
            
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            if (_checkPositionCoroutine == null) return;
            Timing.KillCoroutines(_checkPositionCoroutine.Value);
            _checkPositionCoroutine = null;
            
            base.OnDisabled();
        }
    
    }
}