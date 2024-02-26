using Exiled.API.Interfaces;

namespace RabbitRollSCPSL.GuardOffDuty
{
    /// <inheritdoc cref="IConfig"/>
    public sealed class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public bool Debug { get; set; }
    }
}