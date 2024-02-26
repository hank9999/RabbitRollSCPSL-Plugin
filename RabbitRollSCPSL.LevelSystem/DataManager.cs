using System.IO;
using Exiled.API.Features;
using Server = PluginAPI.Core.Server;

namespace RabbitRollSCPSL.LevelSystem
{
    public class DataManager
    {
        private string _dataPath = Path.Combine(Paths.Configs, $"LevelSystem/{Server.Port}/");

        public DataManager()
        {
            if (!Directory.Exists(_dataPath))
            {
                Directory.CreateDirectory(_dataPath);
            }
        }
        
        public class PlayerData : IJsonSerializable
        {
            public int KillHuman { get; set; }
            public int KillScp { get; set; }
            public int GetOut { get; set; }
            
            public PlayerData(int killHuman, int killScp, int getOut)
            {
                KillHuman = killHuman;
                KillScp = killScp;
                GetOut = getOut;
            }
        }

        public void Update(string userId, PlayerData data)
        {
            string dataPath = Path.Combine(_dataPath, $"{userId}.json");
            using (StreamWriter sw = File.CreateText(dataPath))
            {
                sw.Write(JsonSerialize.ToJson(data));
            }
        }

        public PlayerData Get(string userId)
        {
            string dataPath = Path.Combine(_dataPath, $"{userId}.json");
            if (!File.Exists(dataPath))
            {
                return new PlayerData(0, 0, 0);
            }

            using (StreamReader sr = File.OpenText(dataPath))
            {
                string json = sr.ReadToEnd();
                PlayerData data = JsonSerialize.FromJson<PlayerData>(json);
                return data;
            }
        }
        
        public PlayerData GetOrNull(string userId)
        {
            string dataPath = Path.Combine(_dataPath, $"{userId}.json");
            if (!File.Exists(dataPath))
            {
                return null;
            }

            using (StreamReader sr = File.OpenText(dataPath))
            {
                string json = sr.ReadToEnd();
                PlayerData data = JsonSerialize.FromJson<PlayerData>(json);
                return data;
            }
        }
    }
}