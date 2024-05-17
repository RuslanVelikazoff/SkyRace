using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    private const string saveKey = "MainSave";

    private bool[] _selectedAirplanes;
    private bool[] _purchasedAirplanes;
    
    private bool[] _purchasedUpgrades;
    
    public int _coin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(saveKey);

        _coin = data.coin;
        _selectedAirplanes = data.selectedAirplanes;
        _purchasedAirplanes = data.purchasedAirplanes;
        _purchasedUpgrades = data.purchasedUpgrades;
        
        Debug.Log("Data load");
    }

    public void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Data save");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            coin = _coin,
            selectedAirplanes = _selectedAirplanes,
            purchasedAirplanes = _purchasedAirplanes,
            purchasedUpgrades = _purchasedUpgrades
        };

        return data;
    }

    public int GetCoinAmount()
    {
        return _coin;
    }

    public bool IsPurchasedAirplane(int index)
    {
        return _purchasedAirplanes[index];
    }

    public void BuyAirplane(int index, int price)
    {
        if (_coin > price)
        {
            _coin -= price;
            _purchasedAirplanes[index] = true;
            Save();
        }
    }

    public bool IsPurchasedUpgrade(int index)
    {
        return _purchasedUpgrades[index];
    }

    public void BuyUpgrade(int index, int price)
    {
        if (_coin > price)
        {
            _coin -= price;
            _purchasedUpgrades[index] = true;
            Save();
        }
    }
}
