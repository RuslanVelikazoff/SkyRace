using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private Button pauseButton;

    [SerializeField] 
    private TextMeshProUGUI coinText;

    [SerializeField] 
    private GameObject pausePanel;

    private void Start()
    {
        ButtonClickAction();
        coinText.text = "0";
        CoinManager.Instance.OnAddCoin += CoinManager_OnAddCoin;
    }

    private void CoinManager_OnAddCoin(object sender, EventArgs e)
    {
        coinText.text = CoinManager.Instance.GetCoinAmount().ToString();
    }

    private void ButtonClickAction()
    {
        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            });
        }
    }
}
