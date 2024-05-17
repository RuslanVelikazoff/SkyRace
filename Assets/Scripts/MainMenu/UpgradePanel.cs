using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button purchaseUpgradeButton1;
    [SerializeField] private Button purchaseUpgradeButton2;
    [SerializeField] private Button purchaseUpgradeButton3;

    [SerializeField] private GameObject shopPanel;

    [SerializeField] private TextMeshProUGUI coinText;
    
    private int priceUpgrade1 = 300;
    private int priceUpgrade2 = 450;
    private int priceUpgrade3 = 700;

    private void OnEnable()
    {
        SetCoinText();
        ShowButtons();
        ButtonClickAction();
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
                shopPanel.SetActive(true);
            });
        }

        if (purchaseUpgradeButton1 != null)
        {
            purchaseUpgradeButton1.onClick.RemoveAllListeners();
            purchaseUpgradeButton1.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.BuyUpgrade(0, priceUpgrade1);
                SetCoinText();
                ShowButtons();

                if (Data.Instance.IsPurchasedUpgrade(0))
                {
                    AudioManager.Instance.Play("BuySound");
                }
            });
        }
        
        if (purchaseUpgradeButton2 != null)
        {
            purchaseUpgradeButton2.onClick.RemoveAllListeners();
            purchaseUpgradeButton2.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.BuyUpgrade(1, priceUpgrade2);
                SetCoinText();
                ShowButtons();

                if (Data.Instance.IsPurchasedUpgrade(1))
                {
                    AudioManager.Instance.Play("BuySound");
                }
            });
        }
        
        if (purchaseUpgradeButton3 != null)
        {
            purchaseUpgradeButton3.onClick.RemoveAllListeners();
            purchaseUpgradeButton3.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.BuyUpgrade(2, priceUpgrade3);
                SetCoinText();
                ShowButtons();

                if (Data.Instance.IsPurchasedUpgrade(2))
                {
                    AudioManager.Instance.Play("BuySound");
                }
            });
        }
    }

    private void SetCoinText()
    {
        coinText.text = Data.Instance.GetCoinAmount().ToString();
    }

    private void ShowButtons()
    {
        if (Data.Instance.IsPurchasedUpgrade(0))
        {
            purchaseUpgradeButton1.gameObject.SetActive(false);
        }
        else
        {
            purchaseUpgradeButton1.gameObject.SetActive(true);
        }

        if (Data.Instance.IsPurchasedUpgrade(1))
        {
            purchaseUpgradeButton2.gameObject.SetActive(false);
        }
        else
        {
            purchaseUpgradeButton2.gameObject.SetActive(true);
        }

        if (Data.Instance.IsPurchasedUpgrade(2))
        {
            purchaseUpgradeButton3.gameObject.SetActive(false);
        }
        else
        {
            purchaseUpgradeButton3.gameObject.SetActive(true);
        }
    }
}
