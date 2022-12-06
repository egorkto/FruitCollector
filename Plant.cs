using System;
using UnityEngine;

[Serializable]
public class Plant : MonoBehaviour
{
    public static event Action<Plant, Plant> Evolve;
    public event Action<Plant> Destroyed;

    public int Cost => cost;
    public Sprite Sprite => renderer.sprite;

    [SerializeField] private int cost;
    [SerializeField] private ParticleSystem effect;
    [SerializeField] private SpriteRenderer renderer;

    public static bool operator ==(Plant plant1, Plant plant2)
    {
        return plant1.renderer.sprite == plant2.renderer.sprite;
    }

    public static bool operator !=(Plant plant1, Plant plant2)
    {
        return !(plant1.renderer.sprite == plant2.renderer.sprite);
    }

    public void TryEvolve(Plant joinedPlant)
    {
        Evolve?.Invoke(this, joinedPlant);
    }

    public void Destroy()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }

    private void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
