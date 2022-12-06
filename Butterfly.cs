using UnityEngine;

public class Butterfly : MonoBehaviour
{
    [SerializeField] private Collider2D flyArea;
    [SerializeField] private float speed;

    private Vector3 point;

    private void Start()
    {
        point = GetRandomPoint();    
    }

    private void Update()
    {
        if (transform.position == point)
        {
            point = GetRandomPoint();
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }

        else
            transform.position = Vector2.MoveTowards(transform.position, point, speed * Time.deltaTime);
    }

    private Vector3 GetRandomPoint()
    {
        var leftBorder = flyArea.bounds.center.x - flyArea.bounds.size.x / 2;
        var rightBorder = flyArea.bounds.center.x + flyArea.bounds.size.x / 2;
        var topBorder = flyArea.bounds.center.y - flyArea.bounds.size.y / 2;
        var bottomBorder = flyArea.bounds.center.y + flyArea.bounds.size.y / 2;
        return new Vector3(Random.Range(leftBorder, rightBorder), Random.Range(bottomBorder, topBorder), transform.position.z);
    }
}
