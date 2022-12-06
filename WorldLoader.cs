using UnityEngine;

public class WorldLoader
{
    private string path;
    private ILoader loader;

    public WorldLoader(string fileName)
    {
        path = Application.persistentDataPath + "/" + fileName;
        loader = new JSONLoader();
    }

    public bool TryLoad()
    {
        if(loader.TryLoad(path, out WorldData data))
        {
            LoadEventsHolder.UpdateData(data);
            return true;
        }
        return false;
    }
}
