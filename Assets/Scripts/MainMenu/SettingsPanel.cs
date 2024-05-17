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
    private Button classicControlButton;
    [SerializeField] 
    private Button expertControlButton;

    [SerializeField] 
    private Sprite onSprite;
    [SerializeField] 
    private Sprite offSprite;
    [SerializeField] 
    private Sprite activeSprite;
    [SerializeField]
    private Sprite inactiveSprite;

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
        SetControlButtonSprite();
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

        if (classicControlButton != null)
        {
            classicControlButton.onClick.RemoveAllListeners();
            classicControlButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                ControlManager.Instance.SetClassicControl();
                SetControlButtonSprite();
            });
        }

        if (expertControlButton != null)
        {
            expertControlButton.onClick.RemoveAllListeners();
            expertControlButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                ControlManager.Instance.SetExpertControl();
                SetControlButtonSprite();
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

    private void SetControlButtonSprite()
    {
        if (ControlManager.Instance.IsClassicControl())
        {
            classicControlButton.GetComponent<Image>().sprite = activeSprite;
            expertControlButton.GetComponent<Image>().sprite = inactiveSprite;
        }

        if (ControlManager.Instance.IsExpertControl())
        {
            classicControlButton.GetComponent<Image>().sprite = inactiveSprite;
            expertControlButton.GetComponent<Image>().sprite = activeSprite;
        }
    }
}
