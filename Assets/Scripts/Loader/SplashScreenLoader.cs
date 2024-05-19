using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenLoader : MonoBehaviour
{
    private float timeDownload = 2f;
    private float timeLeft;

    [SerializeField] private Slider loaderSlider;

    public bool load = true; //for webview

    private void Update()
    {
        if (load)
        {
            if (timeLeft < timeDownload)
            {
                timeLeft += Time.deltaTime;
                loaderSlider.value = timeLeft;
            }
            else
            {
                Screen.orientation = ScreenOrientation.LandscapeRight;
                SceneManager.LoadScene("MainMenuScene");
            }
        }
    }
}
