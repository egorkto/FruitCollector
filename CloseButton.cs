using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject window;

    public void CloseWindow()
    {
        window.SetActive(false);
    }
}
