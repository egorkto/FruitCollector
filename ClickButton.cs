using System;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public event Action Click;

    public void ButtonClick()
    {
        Click?.Invoke();
    }
}
