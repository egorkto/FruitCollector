using UnityEngine;

public class ScaleCalculator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private BoxCollider2D spawnArea;

    public Vector2 GetRandomSpawnPoint()
    {
        var pointX = Random.Range(GetLeftSpawnAreaBorder(), GetRightSpawnAreaBorder());
        var pointY = Random.Range(GetTopSpawnAreaBorder(), GetBottomSpawnAreaBorder());
        return new Vector2(pointX, pointY);
    }

    public float GetRightSpriteBorder()
    {
        var scale = GetScale(renderer);
        var border = scale.x / 2 + renderer.transform.position.x;
        return border;
    }

    public float GetLeftSpriteBorder()
    {
        var scale = GetScale(renderer);
        var border = -scale.x / 2 + renderer.transform.position.x;
        return border;
    }

    private float GetRightSpawnAreaBorder()
    {
        var scale = GetScale(spawnArea);
        var border = scale.x / 2 + spawnArea.transform.position.x + spawnArea.offset.x / 2;
        return border;
    }

    private float GetLeftSpawnAreaBorder()
    {
        var scale = GetScale(spawnArea);
        var border = -scale.x / 2 + spawnArea.transform.position.x + spawnArea.offset.x / 2;
        return border;
    }

    private float GetTopSpawnAreaBorder()
    {
        var scale = GetScale(spawnArea);
        var border = scale.y / 2 + spawnArea.transform.position.y + spawnArea.offset.y / 2;
        return border;
    }

    private float GetBottomSpawnAreaBorder()
    {
        var scale = GetScale(spawnArea);
        var border = -scale.y / 2 + spawnArea.transform.position.y + spawnArea.offset.y / 2;
        return border;
    }

    private Vector2 GetScale(SpriteRenderer renderer)
    {
        var x = renderer.sprite.bounds.size.x * renderer.transform.localScale.x;
        var y = renderer.sprite.bounds.size.y * renderer.transform.localScale.y;
        var scale = new Vector2(x, y);
        return scale;
    }

    private Vector2 GetScale(BoxCollider2D collider)
    {
        var x = collider.bounds.size.x;
        var y = collider.bounds.size.y;
        var scale = new Vector2(x, y);
        return scale;
    }
}
