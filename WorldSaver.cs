using UnityEngine;

public class WorldSaver
{
    private string path;
    private ISaver saver;

    public WorldSaver(string fileName)
    {
        path = Application.persistentDataPath + "/" + fileName;
        saver = new JSONSaver();
    }

    public void Save()
    {
        var worldSaveData = GetSaveData();
        saver.Save(path, worldSaveData);
    }

    private WorldData GetSaveData()
    {
        WorldDataConstructor.ConstructData();
        return WorldDataConstructor.Data;
    }
}
