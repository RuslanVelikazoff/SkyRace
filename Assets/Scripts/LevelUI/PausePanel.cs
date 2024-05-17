using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;
    [SerializeField] 
    private Button restartButton;
    [SerializeField]
    private Button menuButton;

    [SerializeField]
    private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        SetCoinText();
        ButtonClickAction();
    }

    private void SetCoinText()
    {
        coinText.text = CoinManager.Instance.GetCoinAmount().ToString();
    }

    private void ButtonClickAction()
    {
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                Time.timeScale = 1;
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                GameManager.Instance.RestartGame();
            });
        }

        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                GameManager.Instance.BackToMenu();
            });
        }
    }
}
