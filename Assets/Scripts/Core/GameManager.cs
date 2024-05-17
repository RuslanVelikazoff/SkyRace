using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
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
