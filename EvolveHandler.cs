using UnityEngine;

public class EvolveHandler : MonoBehaviour
{
    [SerializeField] private PlantsEvolver[] evolvers;

    private void OnEnable()
    {
        Plant.Evolve += Evolve;
    }

    private void OnDisable()
    {
        Plant.Evolve -= Evolve;
    }

    private void Evolve(Plant evolvedPlant, Plant joinedPlant)
    {
        foreach(var evolver in evolvers)
        {
            if (evolver.TryEvolve(evolvedPlant, joinedPlant))
                break;
        }
    }
}
