using UnityEngine;

public class GameSetup : MonoBehaviour
{
    private const string fileName = "save";

    [SerializeField] private GardensActivator gardensActivator;
    [SerializeField] private PlantsCollection plantsCollection;

    private WorldSaver saver;
    private WorldLoader loader;

    private void Awake()
    {
        saver = new WorldSaver(fileName);
        loader = new WorldLoader(fileName);
    }

    private void Start()
    {
        plantsCollection.ResetCollection();
        if (!loader.TryLoad())
            StartNewGame();
    }

    private void StartNewGame()
    {
        gardensActivator.TryActivateNextGarden();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            saver.Save();
    }
}
