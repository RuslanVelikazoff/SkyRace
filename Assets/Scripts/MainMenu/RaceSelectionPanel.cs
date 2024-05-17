using UnityEngine;
using UnityEngine.UI;

public class RaceSelectionPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField]
    private Button startButton;
    [SerializeField] 
    private Button easyButton;
    [SerializeField]
    private Button mediumButton;
    [SerializeField]
    private Button hardButton;
    [SerializeField] 
    private Button[] selectButton;

    [SerializeField]
    private Sprite selectActiveSprite;
    [SerializeField]
    private Sprite selectInactiveSprite;
    [SerializeField]
    private Sprite easyActiveSprite;
    [SerializeField] 
    private Sprite mediumActiveSprite;
    [SerializeField]
    private Sprite hardActiveSprite;
    [SerializeField]
    private Sprite easyInactiveSprite;
    [SerializeField]
    private Sprite mediumInactiveSprite;
    [SerializeField] 
    private Sprite hardInactiveSprite;

    [SerializeField] 
    private GameObject airplanesPanel;

    private int indexEasyDifficulty = 0;
    private int indexMediumDifficulty = 1;
    private int indexHardDifficulty = 2;

    private void OnEnable()
    {
        SetDifficultyButtonSprite();
        DifficultyButtonAction();
        
        SetSelectButtonSprite();
        SelectButtonAction();
        
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
                airplanesPanel.SetActive(true);
            });
        }

        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Loader.Load(Loader.Scene.GameScene);
            });
        }
    }

    private void SelectButtonAction()
    {
        if (selectButton[0] != null)
        {
            selectButton[0].onClick.RemoveAllListeners();
            selectButton[0].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Select");
                LevelBackground.Instance.SetAzureSprite();
                SetSelectButtonSprite();
            });
        }

        if (selectButton[1] != null)
        {
            selectButton[1].onClick.RemoveAllListeners();
            selectButton[1].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Select");
                LevelBackground.Instance.SetVioletSprite();
                SetSelectButtonSprite();
            });
        }

        if (selectButton[2] != null)
        {
            selectButton[2].onClick.RemoveAllListeners();
            selectButton[2].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Select");
                LevelBackground.Instance.SetCrimsonSprite();
                SetSelectButtonSprite();
            });
        }
    }

    private void SetSelectButtonSprite()
    {
        if (LevelBackground.Instance.IsAzureSelected())
        {
            selectButton[0].GetComponent<Image>().sprite = selectInactiveSprite;
            selectButton[1].GetComponent<Image>().sprite = selectActiveSprite;
            selectButton[2].GetComponent<Image>().sprite = selectActiveSprite;
        }

        if (LevelBackground.Instance.IsVioletSelected())
        {
            selectButton[0].GetComponent<Image>().sprite = selectActiveSprite;
            selectButton[1].GetComponent<Image>().sprite = selectInactiveSprite;
            selectButton[2].GetComponent<Image>().sprite = selectActiveSprite;
        }

        if (LevelBackground.Instance.IsCrimsonSelected())
        {
            selectButton[0].GetComponent<Image>().sprite = selectActiveSprite;
            selectButton[1].GetComponent<Image>().sprite = selectActiveSprite;
            selectButton[2].GetComponent<Image>().sprite = selectInactiveSprite;
        }
    }

    private void DifficultyButtonAction()
    {
        if (easyButton != null)
        {
            easyButton.onClick.RemoveAllListeners();
            easyButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SelectDifficulty(indexEasyDifficulty);
                SetDifficultyButtonSprite();
            });
        }

        if (mediumButton != null)
        {
            mediumButton.onClick.RemoveAllListeners();
            mediumButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SelectDifficulty(indexMediumDifficulty);
                SetDifficultyButtonSprite();
            });
        }

        if (hardButton != null)
        {
            hardButton.onClick.RemoveAllListeners();
            hardButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SelectDifficulty(indexHardDifficulty);
                SetDifficultyButtonSprite();
            });
        }
    }

    private void SetDifficultyButtonSprite()
    {
        switch (Data.Instance.GetDifficultyIndex())
        {
            case 0:
                easyButton.GetComponent<Image>().sprite = easyActiveSprite;
                mediumButton.GetComponent<Image>().sprite = mediumInactiveSprite;
                hardButton.GetComponent<Image>().sprite = hardInactiveSprite;
                break;
            case 1:
                easyButton.GetComponent<Image>().sprite = easyInactiveSprite;
                mediumButton.GetComponent<Image>().sprite = mediumActiveSprite;
                hardButton.GetComponent<Image>().sprite = hardInactiveSprite;
                break;
            case 2:
                easyButton.GetComponent<Image>().sprite = easyInactiveSprite;
                mediumButton.GetComponent<Image>().sprite = mediumInactiveSprite;
                hardButton.GetComponent<Image>().sprite = hardActiveSprite;
                break;
        }
    }

}
