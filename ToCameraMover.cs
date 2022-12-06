using System;
using System.Collections.Generic;
using UnityEngine;

public class ToCameraMover : MonoBehaviour
{
    public event Action<Garden> ChangedActiveGarden;

    [SerializeField] private Camera camera;
    [SerializeField] private GameObject movebleObject;
    [SerializeField] private GardensActivator activator;
    [SerializeField] private float sensitivity = 1;

    private Vector3 cursorPosition => camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));

    private List<Garden> gardens = new List<Garden>();
    private List<float> checkPoints = new List<float>();
    private float rightBorder, leftBorder, cameraWidth, cameraHeight, startDragObjectPositionX, startDragCursorPositionX;

    private void Awake()
    {
        cameraHeight = camera.orthographicSize * 2;
        cameraWidth = camera.aspect * cameraHeight;
    }

    public void OnEnable()
    {
        activator.GardenActivated += AddGarden;
    }

    private void OnDisable()
    {
        activator.GardenActivated -= AddGarden;
    }

    private void AddGarden(Garden garden)
    {
        if (gardens.Count == 0)
            ChangedActiveGarden?.Invoke(garden);
        gardens.Add(garden);
        checkPoints.Add(garden.transform.position.x);
        TryUpdateBorders();
    }

    private void TryUpdateBorders()
    {
        if (gardens.Count > 0)
        {
            rightBorder = gardens[gardens.Count - 1].Calculator.GetRightSpriteBorder() - cameraWidth / 2;
            leftBorder = gardens[0].Calculator.GetLeftSpriteBorder() + cameraWidth / 2;
        }
    }

    private void OnMouseDown()
    {
        startDragCursorPositionX = cursorPosition.x;
        startDragObjectPositionX = movebleObject.transform.position.x;
    }

    private void OnMouseDrag()
    {
        var delta = cursorPosition.x - startDragCursorPositionX;
        var objectPosition = movebleObject.transform.position;
        var objectXPosition = Mathf.Clamp(startDragObjectPositionX + delta * sensitivity, leftBorder, rightBorder);
        movebleObject.transform.position = new Vector3(objectXPosition, objectPosition.y, objectPosition.z);
    }

    private void OnMouseUp()
    {
        FocusCamera(FindClosestGardenIndex());
    }

    private void FocusCamera(int index)
    {
        movebleObject.transform.position = new Vector3(checkPoints[index], movebleObject.transform.position.y, movebleObject.transform.position.z);
        ChangedActiveGarden?.Invoke(gardens[index]);
    }

    private int FindClosestGardenIndex()
    {
        var index = 0;
        float closestDistance = float.MaxValue;
        for(var i = 0; i < gardens.Count; i++)
        {
            var distance = Vector2.Distance(camera.transform.position, gardens[i].transform.position);
            if (distance < closestDistance)
            {
                index = i;
                closestDistance = distance;
            }
        }
        return index;
    }
}
