using System;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Item;
using Exiled.Events.EventArgs.Player;

namespace RabbitRollSCPSL.InfiniteAmmo
{
    public class EventHandlers
    {
        public void OnChangingAmmo(ChangingAmmoEventArgs ev)
        {
            Log.Debug("OnChangingAmmo Targeted!");
            if (ev.Player == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            if (!ev.Item.IsWeapon) return;
            ev.Player.SetAmmo(ev.Firearm.AmmoType, 200);
            Log.Debug($"{ev.Player.Nickname} Set Ammo 200");
        }

        public void OnDroppingAmmo(DroppingAmmoEventArgs ev)
        {
            Log.Debug("OnDroppingAmmo Targeted!");
            if (ev.Player == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            ev.IsAllowed = false;
            Log.Debug($"{ev.Player.Nickname} Prohibited Drop Ammo");
        }

        public void OnShot(ShotEventArgs ev)
        {
            Log.Debug("OnShot Targeted!");
            if (ev.Player == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            if (!ev.Item.IsWeapon) return;
            ev.Player.SetAmmo(ev.Firearm.AmmoType, 200);
            Log.Debug($"{ev.Player.Nickname} Set Ammo 200");
        }

        public void OnChangedItem(ChangedItemEventArgs ev)
        {
            Log.Debug("OnChangedItem Targeted!");
            if (ev.Player?.Nickname == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            if (ev.Item == null) return;
            if (!ev.Item.IsWeapon) return;
            try
            {
                ev.Player.SetAmmo(((Firearm)ev.Item).AmmoType, 200);
                Log.Debug($"{ev.Player.Nickname} Set Ammo 200");
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void OnChangingItem(ChangingItemEventArgs ev)
        {
            Log.Debug("OnChangedItem Targeted!");
            if (ev.Player?.Nickname == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            if (ev.Item == null) return;
            if (ev.Item.IsWeapon) return;
            try
            {
                Log.Debug(ev.Player.GetAmmo(((Firearm)ev.Item).AmmoType));
                ev.Player.SetAmmo(((Firearm)ev.Item).AmmoType, 1);
                Log.Debug(ev.Player.GetAmmo(((Firearm)ev.Item).AmmoType));
                ev.IsAllowed = true;
            }
            catch (Exception)
            {
                // ignored
            }
        }
        
        public void OnDroppingItem(DroppingItemEventArgs ev)
        {
            Log.Debug("OnDroppingItem Targeted!");
            if (ev.Player?.Nickname == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            if (ev.Item == null) return;
            if (!ev.Item.IsWeapon) return;
            try
            {
                Log.Debug(ev.Player.GetAmmo(((Firearm)ev.Item).AmmoType));
                ev.Player.SetAmmo(((Firearm)ev.Item).AmmoType, 1);
                Log.Debug(ev.Player.GetAmmo(((Firearm)ev.Item).AmmoType));
                ev.IsAllowed = true;
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}