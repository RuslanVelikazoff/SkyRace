using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private PlayerMovement playerMovement;
    [SerializeField] 
    private EndRacePanel endRacePanel;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
    }

    public void BoostSpeed()
    {
        playerMovement.ActivateBoostSpeed();
    }

    public void WinGame()
    {
        AudioManager.Instance.Play("Win");
        Time.timeScale = 0;
        endRacePanel.OpenPanel(1);
    }

    public void LoseGame()
    {
        AudioManager.Instance.Play("Lose");
        Time.timeScale = 0;
        endRacePanel.OpenPanel(2);
    }

    public void RestartGame()
    {
        Data.Instance.AddCoin(CoinManager.Instance.GetCoinAmount());
        Loader.Load(Loader.Scene.GameScene);
    }

    public void BackToMenu()
    {
        Data.Instance.AddCoin(CoinManager.Instance.GetCoinAmount());
        Loader.Load(Loader.Scene.MainMenuScene);
    }
}
