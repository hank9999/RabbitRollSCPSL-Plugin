using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Interactables.Interobjects.DoorUtils;
using RabbitRollSCPSL.RemoteCard.Extensions;

namespace RabbitRollSCPSL.RemoteCard
{
    public class EventHandlers
    {
        public void OnDoorInteracting(InteractingDoorEventArgs ev)
        {
            Log.Debug("OnDoorInteracting Target");

            if (ev.IsAllowed) return;
            if (ev.Player?.Nickname == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
        
            if (ev.Door?.RequiredPermissions?.RequiredPermissions == null) return;
            
            if (ev.Player.HasKeycardPermission(ev.Door.RequiredPermissions.RequiredPermissions))
            {
                ev.IsAllowed = true;
                Log.Debug($"{ev.Player.Nickname} RemoteCard Allowed");
            }
        }
    
        public void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev)
        {
            Log.Debug("OnActivatingWarheadPanel Target");
        
            if (ev.IsAllowed) return;
            if (ev.Player?.Nickname == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            
            if (ev.Player.HasKeycardPermission(KeycardPermissions.AlphaWarhead))
            {
                ev.IsAllowed = true;
                Log.Debug($"{ev.Player.Nickname} RemoteCard Allowed");
            }
        }
    
        public void OnUnlockingGenerator(UnlockingGeneratorEventArgs ev)
        {
            Log.Debug("OnUnlockingGenerator Target");
        
            if (ev.IsAllowed) return;
            if (ev.Player?.Nickname == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            
            if (ev.Player.HasKeycardPermission(KeycardPermissions.ArmoryLevelTwo))
            {
                ev.IsAllowed = true;
                Log.Debug($"{ev.Player.Nickname} RemoteCard Allowed");
            }
        }
    
        public void OnInteractingLocker(InteractingLockerEventArgs ev)
        {
            Log.Debug("OnInteractingLocke Target");
        
            if (ev.IsAllowed) return;
            if (ev.Player?.Nickname == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
        
            if (ev.Chamber == null) return;
            
            if (ev.Player.HasKeycardPermission(ev.Chamber.RequiredPermissions))
            {
                ev.IsAllowed = true;
                Log.Debug($"{ev.Player.Nickname} RemoteCard Allowed");
            }
        }
    }
}