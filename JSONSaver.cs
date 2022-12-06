using System.IO;
using UnityEngine;

public class JSONSaver : ISaver
{
    private const string expansion = ".json";

    public void Save(string path, WorldData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path + expansion, json);
    }
}
