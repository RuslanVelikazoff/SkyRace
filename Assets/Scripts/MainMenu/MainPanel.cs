using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] 
    private Button playButton;
    [SerializeField] 
    private Button settingsButton;
    [SerializeField] 
    private Button shopButton;
    [SerializeField] 
    private Button exitButton;

    [SerializeField] 
    private GameObject planeSelectionPanel;
    [SerializeField] 
    private GameObject settingsPanel;
    [SerializeField] 
    private GameObject shopPanel;

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                planeSelectionPanel.SetActive(true);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                settingsPanel.SetActive(true);
            });
        }

        if (shopButton != null)
        {
            shopButton.onClick.RemoveAllListeners();
            shopButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                shopPanel.SetActive(true);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }
    }
}
