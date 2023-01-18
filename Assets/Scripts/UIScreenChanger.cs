using UnityEngine;

public class UIScreenChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject screenToActivate;

    [SerializeField]
    private GameObject screenToDeactivate;

    public void ScreenChange()
    {
        screenToActivate.SetActive(true);
        screenToDeactivate.SetActive(false);
    }
}
