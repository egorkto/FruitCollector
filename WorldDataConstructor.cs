using System;

public static class WorldDataConstructor
{
    public static event Action SetData;

    public static WorldData Data;

    public static void ConstructData()
    {
        SetData?.Invoke();
    }
}
    
