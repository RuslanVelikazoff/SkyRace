using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndRacePanel : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI placeText;

    public void OpenPanel(int place)
    {
        this.gameObject.SetActive(true);
        ButtonClickAction();
        SetCoinText();
        SetPlaceText(place);
    }

    private void ButtonClickAction()
    {
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

    private void SetCoinText()
    {
        coinText.text = CoinManager.Instance.GetCoinAmount().ToString();
    }

    private void SetPlaceText(int place)
    {
        placeText.text = place.ToString();
    }
}
