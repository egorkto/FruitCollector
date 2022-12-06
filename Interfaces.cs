public interface ISaver
{
    public void Save(string path, WorldData data);
}

public interface ILoader
{
    public bool TryLoad(string path, out WorldData data);
}