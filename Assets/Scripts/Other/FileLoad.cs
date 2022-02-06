using System.IO;
using UnityEngine;

namespace Other
{
    public static class FileLoad
    {
        static string path = Application.persistentDataPath + "/save.json";
        public static GameData GetGameData()
        {
            GameData gameData = new GameData();
            if (File.Exists(path))
            {
                var data = File.ReadAllText(path);
                gameData = JsonUtility.FromJson<GameData>(data);
            }
            return gameData;
        }

        public static void WriteData(GameData gameData)
        {
            var data = JsonUtility.ToJson(gameData);
            File.WriteAllText(path,data);
        }
    }
}