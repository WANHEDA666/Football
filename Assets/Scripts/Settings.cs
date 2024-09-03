using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button back;
    [SerializeField] private Button music;
    [SerializeField] private Image musicImage;
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Button privacy;
    [SerializeField] private Button terms;
    [SerializeField] private Button feedback;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("music") == 1)
        {
            musicImage.sprite = musicOff;
        }
        else
        {
            musicImage.sprite = musicOn;
        }
        back.onClick.AddListener((() =>
        {
            startScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        music.onClick.AddListener((() =>
        {
            if (musicImage.sprite == musicOn)
            {
                musicImage.sprite = musicOff;
                audioSource.Stop();
                PlayerPrefs.SetInt("music", 1);
            }
            else
            {
                musicImage.sprite = musicOn;
                audioSource.Play();
                PlayerPrefs.SetInt("music", 0);
            }
        }));
        privacy.onClick.AddListener((() =>
        {
            var webView = gameObject.AddComponent<UniWebView>();
            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
            webView.SetShowToolbar(true);
            webView.SetBackButtonEnabled(true);
            webView.Load("https://awiclo.co.uk/privacy/");
            webView.Show();
        }));
        terms.onClick.AddListener((() =>
        {
            var webView = gameObject.AddComponent<UniWebView>();
            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
            webView.SetShowToolbar(true);
            webView.SetBackButtonEnabled(true);
            webView.Load("https://awiclo.co.uk/terms/");
            webView.Show();
        }));
        feedback.onClick.AddListener((() =>
        {
            var webView = gameObject.AddComponent<UniWebView>();
            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
            webView.SetShowToolbar(true);
            webView.SetBackButtonEnabled(true);
            webView.Load("https://forms.gle/hQLd2z6jMSNRMXCD6");
            webView.Show();
        }));
    }

    private void OnDisable()
    {
        back.onClick.RemoveAllListeners();
        music.onClick.RemoveAllListeners();
        privacy.onClick.RemoveAllListeners();
        terms.onClick.RemoveAllListeners();
        feedback.onClick.RemoveAllListeners();
    }
}