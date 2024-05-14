using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    private const string saveKey = "MainSave";

    private int _coin;

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
            coin = _coin
        };

        return data;
    }
}
