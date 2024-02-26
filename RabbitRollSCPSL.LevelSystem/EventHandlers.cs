using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace RabbitRollSCPSL.LevelSystem
{
    public class EventHandlers
    {
        private Exp _exp = new Exp();
        
        ~EventHandlers()
        {
            _exp = null;
        }
        
        public void OnDied(DiedEventArgs ev)
        {
            if (ev.Player?.Nickname == null) return;
            if (ev.Player.Nickname == "Dedicated Server") return;
            if (ev.Attacker?.Nickname == null) return;
            if (ev.Attacker.Nickname == "Dedicated Server") return;
            
            Log.Info($"{ev.Player.Nickname} was killed by {ev.Attacker.Nickname}!");
            Log.Info(ev.Player.Nickname + " " + (ev.Player.IsHuman ? "true Human" : "false not Human"));
            Log.Info(ev.Attacker.Nickname + " " + (ev.Attacker.IsHuman ? "true Human" : "false not Human"));
            if (ev.Attacker.IsScp && ev.Player.IsHuman)
            {
                Log.Info("Targeted kill human");
                int level = _exp.GetLevel(ev.Player.RawUserId);
                int exp =  _exp.AddKillHuman(ev.Attacker.RawUserId);
                int levelNew = _exp.GetLevel(ev.Player.RawUserId);
                int fullExp = _exp.GetFullExp(ev.Player.RawUserId);
                int nextLevelExp = _exp.GetLevelExp(levelNew + 1);
                if (levelNew == level)
                {
                    ev.Attacker.Broadcast(2, $"击杀+1! +{exp}经验! 你现在的等级是{levelNew}级! {fullExp} / {nextLevelExp}"); 
                }
                else
                {
                    ev.Attacker.Broadcast(2, $"击杀+1! +{exp}经验! 恭喜, 升级了! {level}级 -> {levelNew}级! {fullExp} / {nextLevelExp}"); 
                }
            } else if (ev.Attacker.IsHuman && ev.Player.IsScp)
            {
                Log.Info("Targeted kill scp");
                int level = _exp.GetLevel(ev.Player.RawUserId);
                int exp =  _exp.AddKillScp(ev.Attacker.RawUserId, isScp0492: ev.Attacker.Role == RoleTypeId.Scp0492);
                int levelNew = _exp.GetLevel(ev.Player.RawUserId);
                int fullExp = _exp.GetFullExp(ev.Player.RawUserId);
                int nextLevelExp = _exp.GetLevelExp(levelNew + 1);
                if (levelNew == level)
                {
                    ev.Attacker.Broadcast(2, $"击杀+1! +{exp}经验! 你现在的等级是{levelNew}级! {fullExp} / {nextLevelExp}");
                }
                else
                {
                    ev.Attacker.Broadcast(2, $"击杀+1! +{exp}经验! 恭喜, 升级了! {level}级 -> {levelNew}级! {fullExp} / {nextLevelExp}"); 
                }
            }
        }

        public void OnEscaping(EscapingEventArgs ev)
        {
            if (!ev.IsAllowed) return;
            int level = _exp.GetLevel(ev.Player.RawUserId);
            int exp = _exp.AddEscape(ev.Player.RawUserId);
            int levelNew = _exp.GetLevel(ev.Player.RawUserId);
            int fullExp = _exp.GetFullExp(ev.Player.RawUserId);
            int nextLevelExp = _exp.GetLevelExp(levelNew + 1);
            if (levelNew == level)
            {
                ev.Player.Broadcast(2, $"你正在逃离! +{exp}经验! 你现在的等级是{levelNew}级! {fullExp} / {nextLevelExp}"); 
            }
            else
            {
                ev.Player.Broadcast(2, $"你正在逃离! +{exp}经验! 恭喜, 升级了! {level}级 -> {levelNew}级! {fullExp} / {nextLevelExp}"); 
            }
        }
    }
}