using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] 
    private Button airplanesButton;
    [SerializeField] 
    private Button upgradesButton;
    [SerializeField] 
    private Button backButton;
    
    [SerializeField] 
    private TextMeshProUGUI coinText;

    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField] 
    private GameObject airplanesPanel;
    [SerializeField] 
    private GameObject upgradesPanel;

    private void OnEnable()
    {
        ButtonClickAction();
        SetCoinText();
    }

    private void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (airplanesButton != null)
        {
            airplanesButton.onClick.RemoveAllListeners();
            airplanesButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                airplanesPanel.SetActive(true);
            });
        }

        if (upgradesButton != null)
        {
            upgradesButton.onClick.RemoveAllListeners();
            upgradesButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                upgradesPanel.SetActive(true);
            });
        }
    }

    private void SetCoinText()
    {
        coinText.text = Data.Instance.GetCoinAmount().ToString();
    }
}
