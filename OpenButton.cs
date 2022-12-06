using UnityEngine;

public class OpenButton : MonoBehaviour
{
    [SerializeField] private GameObject window;

    public void OpenWindow()
    {
        window.SetActive(true);
    }
}
