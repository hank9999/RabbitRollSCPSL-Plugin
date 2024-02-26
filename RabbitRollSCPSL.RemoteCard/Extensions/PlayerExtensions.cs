using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Interactables.Interobjects.DoorUtils;

namespace RabbitRollSCPSL.RemoteCard.Extensions
{
    public static class PlayerExtensions
    {
        public static bool HasKeycardPermission(this Player player, KeycardPermissions permissions, bool requiresAllPermissions = false)
        {

            if (requiresAllPermissions)
            {
                return player.Items.OfType<Keycard>().Any(item => item.Base.Permissions.HasFlagFast(permissions));
            }

            return player.Items.OfType<Keycard>().Any(item => (item.Base.Permissions & permissions) != 0);
        }
    }
}