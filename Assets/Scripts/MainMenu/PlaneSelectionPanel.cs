using UnityEngine;
using UnityEngine.UI;

public class PlaneSelectionPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button[] selectButton;
    [SerializeField] 
    private Button continueButton;

    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField] 
    private GameObject raceSelectPanel;

    [SerializeField]
    private Sprite activeSprite;
    [SerializeField] 
    private Sprite inactiveSprite;

    private void OnEnable()
    {
        ButtonClickAction();
        SetButtonSprite();
        ShowButton();
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

        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                raceSelectPanel.SetActive(true);
            });
        }

        if (selectButton[0] != null)
        {
            selectButton[0].onClick.RemoveAllListeners();
            selectButton[0].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Select");
                Data.Instance.SelectAirplane(0);
                SetButtonSprite();
            });
        }
        
        if (selectButton[1] != null)
        {
            selectButton[1].onClick.RemoveAllListeners();
            selectButton[1].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Select");
                Data.Instance.SelectAirplane(1);
                SetButtonSprite();
            });
        }
        
        if (selectButton[2] != null)
        {
            selectButton[2].onClick.RemoveAllListeners();
            selectButton[2].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Select");
                Data.Instance.SelectAirplane(2);
                SetButtonSprite();
            });
        }
    }

    private void ShowButton()
    {
        if (Data.Instance.IsPurchasedAirplane(0))
        {
            selectButton[0].gameObject.SetActive(true);
        }
        else
        {
            selectButton[0].gameObject.SetActive(false);
        }
        
        if (Data.Instance.IsPurchasedAirplane(1))
        {
            selectButton[1].gameObject.SetActive(true);
        }
        else
        {
            selectButton[1].gameObject.SetActive(false);
        }
        
        if (Data.Instance.IsPurchasedAirplane(2))
        {
            selectButton[2].gameObject.SetActive(true);
        }
        else
        {
            selectButton[2].gameObject.SetActive(false);
        }
    }

    private void SetButtonSprite()
    {
        if (Data.Instance.IsSelectedAirplane(0))
        {
            selectButton[0].GetComponent<Image>().sprite = inactiveSprite;
            selectButton[1].GetComponent<Image>().sprite = activeSprite;
            selectButton[2].GetComponent<Image>().sprite = activeSprite;
        }
        
        if (Data.Instance.IsSelectedAirplane(1))
        {
            selectButton[0].GetComponent<Image>().sprite = activeSprite;
            selectButton[1].GetComponent<Image>().sprite = inactiveSprite;
            selectButton[2].GetComponent<Image>().sprite = activeSprite;
        }
        
        if (Data.Instance.IsSelectedAirplane(2))
        {
            selectButton[0].GetComponent<Image>().sprite = activeSprite;
            selectButton[1].GetComponent<Image>().sprite = activeSprite;
            selectButton[2].GetComponent<Image>().sprite = inactiveSprite;
        }
    }
}
