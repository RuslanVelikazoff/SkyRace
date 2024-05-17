using UnityEngine;
using UnityEngine.UI;

public class LevelBackground : MonoBehaviour
{
    private const string PLAYER_PREFS_BACKGROUND = "Background";
    private const string PLAYER_PREFS_AZURE = "Azure";
    private const string PLAYER_PREFS_VIOLET = "Violet";
    private const string PLAYER_PREFS_CRIMSON = "Crimson";
    
    [SerializeField] 
    private Image backgroundImage;

    [SerializeField]
    private Sprite azureSprite;
    [SerializeField]
    private Sprite violetSprite;
    [SerializeField]
    private Sprite crimsonSprite;

    public static LevelBackground Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BACKGROUND))
        {
            if (IsAzureSelected())
            {
                SetAzureSprite();
            }
            else if (IsVioletSelected())
            {
                SetVioletSprite();
            }
            else if (IsCrimsonSelected())
            {
                SetCrimsonSprite();
            }
        }
        else
        {
            SetAzureSprite();
        }
    }

    private bool IsAzureSelected()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_BACKGROUND) == PLAYER_PREFS_AZURE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private bool IsVioletSelected()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_BACKGROUND) == PLAYER_PREFS_VIOLET)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private bool IsCrimsonSelected()
    {
        if (PlayerPrefs.GetString(PLAYER_PREFS_BACKGROUND) == PLAYER_PREFS_CRIMSON)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetAzureSprite()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_BACKGROUND, PLAYER_PREFS_AZURE);
        backgroundImage.sprite = azureSprite;
    }

    public void SetVioletSprite()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_BACKGROUND, PLAYER_PREFS_VIOLET);
        backgroundImage.sprite = violetSprite;
    }

    public void SetCrimsonSprite()
    {
        PlayerPrefs.SetString(PLAYER_PREFS_BACKGROUND, PLAYER_PREFS_CRIMSON);
        backgroundImage.sprite = crimsonSprite;
    }
}
