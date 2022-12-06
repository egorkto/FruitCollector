using System.IO;
using UnityEngine;

public class JSONLoader : ILoader
{
    private const string expansion = ".json";

    public bool TryLoad(string path, out WorldData data)
    {
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(path + expansion))
        {
            var json = File.ReadAllText(path + expansion);
            data = JsonUtility.FromJson<WorldData>(json);
            return true;
        }
        data = new WorldData();
        return false;
    }
}
