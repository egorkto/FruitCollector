using UnityEngine;

public class PlantMover : MonoBehaviour
{
    [SerializeField] private Plant plant;

    private Camera camera;
    private bool canJoin = false;
    private bool captured = false;
    private Plant candidate = null;

    private void Start()
    {
        camera = Camera.main;
    }

    private void OnMouseDown()
    {
        captured = true;
    }

    private void OnMouseDrag()
    {
        var cursor = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        plant.transform.position = new Vector2(cursor.x, cursor.y);
    }

    private void OnMouseUp()
    {
        captured = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Plant joinedPlant))
        {
            if (plant == joinedPlant)
                candidate = joinedPlant;
        }   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Plant joinedPlant))
        {
            if (captured)
                canJoin = true;
            else if (canJoin && candidate)
            {
                plant.TryEvolve(candidate);
                canJoin = false;
                candidate = null;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Plant joinedPlant))
        {
            if (captured)
                canJoin = false;
            if (candidate)
                candidate = null;
        }
    }
}
