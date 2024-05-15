using UnityEngine;

public class ControlUI : MonoBehaviour
{
    [SerializeField] private GameObject classicControl;
    [SerializeField] private GameObject expertControl;

    private void Start()
    {
        if (ControlManager.Instance.IsClassicControl())
        {
            classicControl.SetActive(true);
            expertControl.SetActive(false);
        }

        if (ControlManager.Instance.IsExpertControl())
        {
            expertControl.SetActive(true);
            classicControl.SetActive(false);
        }
    }
}
