using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AirplanesPanel : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button purchaseAirplaneButton1;
    [SerializeField] private Button purchaseAirplaneButton2;

    [SerializeField] private TextMeshProUGUI coinText;
    
    [SerializeField] private GameObject shopPanel;

    private int priceAirplane1 = 400;
    private int priceAirplane2 = 600;

    private void OnEnable()
    {
        ShowButtons();
        SetCoinText();
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

        if (purchaseAirplaneButton1 != null)
        {
            purchaseAirplaneButton1.onClick.RemoveAllListeners();
            purchaseAirplaneButton1.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.BuyAirplane(1, priceAirplane1);
                ShowButtons();
                SetCoinText();
                
                if (Data.Instance.IsPurchasedAirplane(1))
                {
                    AudioManager.Instance.Play("BuySound");
                }
            });
        }

        if (purchaseAirplaneButton2 != null)
        {
            purchaseAirplaneButton2.onClick.RemoveAllListeners();
            purchaseAirplaneButton2.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.BuyAirplane(2, priceAirplane2);
                ShowButtons();
                SetCoinText();
                
                if (Data.Instance.IsPurchasedAirplane(1))
                {
                    AudioManager.Instance.Play("BuySound");
                }
            });
        }
    }

    private void ShowButtons()
    {
        if (Data.Instance.IsPurchasedAirplane(1))
        {
            purchaseAirplaneButton1.gameObject.SetActive(false);
        }
        else
        {
            purchaseAirplaneButton1.gameObject.SetActive(true);
        }

        if (Data.Instance.IsPurchasedAirplane(2))
        {
            purchaseAirplaneButton2.gameObject.SetActive(false);
        }
        else
        {
            purchaseAirplaneButton2.gameObject.SetActive(true);
        }
    }

    private void SetCoinText()
    {
        coinText.text = Data.Instance.GetCoinAmount().ToString();
    }
}
