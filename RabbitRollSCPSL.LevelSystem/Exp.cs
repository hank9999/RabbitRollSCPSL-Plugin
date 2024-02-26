using System.Collections.Generic;
using System.Linq;

namespace RabbitRollSCPSL.LevelSystem
{
    public class Exp
    {
        private const int KillHuman = 10;
        private const int KillScp = 100;

        private const int KillScpO492 = 10;
        // public int Escape => new Random().Next(10, 500);
        private const int Escape = 50;
        private DataManager _dataManager = new DataManager(); 
        IEnumerable<int> _levelExp = Enumerable.Range(0, int.MaxValue).Select(x => x * 100);
        
        ~Exp()  
        {
            _dataManager = null;
        }
        
        public DataManager.PlayerData Get(string userId)
        {
            DataManager.PlayerData playerData = _dataManager.Get(userId);
            return playerData;
        }
        
        public int AddKillHuman(string userId)
        {
            DataManager.PlayerData playerData = _dataManager.Get(userId);
            playerData.KillHuman += KillHuman;
            _dataManager.Update(userId, playerData);
            return KillHuman;
        }
        
        public int AddKillScp(string userId, bool isScp0492 = false)
        {
            DataManager.PlayerData playerData = _dataManager.Get(userId);
            playerData.KillScp += isScp0492 ? KillScpO492 : KillScp;
            _dataManager.Update(userId, playerData);
            return KillScp;
        }
        
        public int AddEscape(string userId)
        {
            DataManager.PlayerData playerData = _dataManager.Get(userId);
            int escapeExp = Escape;
            playerData.GetOut += escapeExp;
            _dataManager.Update(userId, playerData);
            return escapeExp;
        }
        
        public int GetLevel(string userId)
        {
            int fullExp = GetFullExp(userId);
            int level = 0;
            foreach (int exp in _levelExp)
            {
                if (fullExp <= exp) break;
                level++;
            }
            return level;
        }
        
        public int GetFullExp(string userId)
        {
            DataManager.PlayerData playerData = _dataManager.Get(userId);
            int fullExp = playerData.KillHuman + playerData.KillScp + playerData.GetOut;
            return fullExp;
        }
        
        public int GetLevelExp(int level)
        {
            return _levelExp.ElementAt(level);
        }
    }
}