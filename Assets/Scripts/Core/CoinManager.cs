using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public event EventHandler OnAddCoin;
    
    public static CoinManager Instance { get; private set; }

    private int collectedCoin;

    private void Awake()
    {
        Instance = this;
        collectedCoin = 0;
    }

    public void AddCoin()
    {
        collectedCoin++;
        OnAddCoin?.Invoke(this, EventArgs.Empty);
    }

    public int GetCoinAmount()
    {
        return collectedCoin;
    }
}
