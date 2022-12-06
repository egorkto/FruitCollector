using UnityEngine;

public class CollectorPlant : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;

    private Color currentColor = new Color(1, 1, 1);

    public static bool operator ==(CollectorPlant collectorPlant, Plant plant)
    {
        return collectorPlant.renderer.sprite == plant.Sprite;
    }

    public static bool operator !=(CollectorPlant collectorPlant, Plant plant)
    {
        return !(collectorPlant.renderer.sprite == plant.Sprite);
    }

    public void SetColor(Color color)
    {
        currentColor = color;
        foreach (var child in GetComponentsInChildren<SpriteRenderer>())
            child.color = color;
    }

    public Color GetColor()
    {
        return currentColor;
    }

    public void SetData(CollectorPlantData data)
    {
        SetColor(data.Color);
    }

    public CollectorPlantData GetData()
    {
        return new CollectorPlantData() { Color = currentColor };
    }
}
