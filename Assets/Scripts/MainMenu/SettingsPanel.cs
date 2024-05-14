using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField]
    private Button soundButton;
    [SerializeField] 
    private Button musicButton;

    [SerializeField] 
    private Sprite onSprite;
    [SerializeField] 
    private Sprite offSprite;

    [SerializeField] 
    private GameObject mainPanel;

    private void Start()
    {
        SetMusicButtonSprite();
        SetSoundButtonSprite();
        ButtonClickAction();
    }

    private void OnEnable()
    {
        SetMusicButtonSprite();
        SetSoundButtonSprite();
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
                mainPanel.SetActive(true);
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                
                if (AudioManager.Instance.SoundPlay())
                {
                    AudioManager.Instance.OffSounds();
                }
                else
                {
                    AudioManager.Instance.OnSounds();
                }
                
                SetSoundButtonSprite();
            });
        }

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");

                if (AudioManager.Instance.MusicPlay())
                {
                    AudioManager.Instance.OffMusic();
                }
                else
                {
                    AudioManager.Instance.OnMusic();
                }
                
                SetMusicButtonSprite();
            });
        }
    }

    private void SetMusicButtonSprite()
    {
        if (AudioManager.Instance.MusicPlay())
        {
            musicButton.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = offSprite;
        }
    }

    private void SetSoundButtonSprite()
    {
        if (AudioManager.Instance.SoundPlay())
        {
            soundButton.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = offSprite;
        }
    }
}
