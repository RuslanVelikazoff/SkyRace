using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenLoader : MonoBehaviour
{
    private float timeDownload = 2f;
    private float timeLeft;

    public bool load = true; //for webview

    private void Update()
    {
        if (load)
        {
            if (timeLeft < timeDownload)
            {
                timeLeft += Time.deltaTime;
            }
            else
            {
                Screen.orientation = ScreenOrientation.LandscapeRight;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
