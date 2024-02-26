using System.Collections.Generic;
using Exiled.API.Features;
using MEC;
using PlayerRoles;

namespace RabbitRollSCPSL.GuardOffDuty
{
    public class Coroutines
    {
        public static IEnumerator<float> CheckPlayerPostionCoroutine()
        {
            for (;;) // 无限循环
            {
                foreach (var player in Player.List)
                {
                    if (player.Role == null) continue;
                    
                    if (player.Role != RoleTypeId.FacilityGuard) continue;
                    
                    var position = player.Position;
                    
                    if (!(position.x >= 121.413) || !(position.x <= 126.229)) continue;
                    if (!(position.z >= 19.359) || !(position.z <= 23.217)) continue;
                    if (!(position.y >= 988.6) || !(position.y <= 991)) continue;
                    
                    player.Role.Set(RoleTypeId.NtfSergeant);
                    Log.Debug($"{player.Nickname} Guard to NTF Target");
                }
                yield return Timing.WaitForSeconds(0.5f); // 等待0.5秒
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}