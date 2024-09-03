using UnityEngine;
using UnityEngine.UI;

public class Privacy : MonoBehaviour
{
    [SerializeField] private GameObject startGameScreen;
    [SerializeField] private Button privacy;
    [SerializeField] private Sprite privacyOn;
    [SerializeField] private Button privacyLink;
    [SerializeField] private Button terms;
    [SerializeField] private Sprite termsOn;
    [SerializeField] private Button termsLink;
    [SerializeField] private Sprite continueButtonOn;
    [SerializeField] private Button continueButton;

    private int needed;

    private void Start()
    {
        PlayerPrefs.SetInt("rocket" + 0, 1);
        PlayerPrefs.SetInt("boot" + 0, 1);
        PlayerPrefs.SetInt("boot" + "x", 1);
        PlayerPrefs.SetInt("rocket" + "x", 1);
        privacy.onClick.AddListener((() =>
        {
            privacy.image.sprite = privacyOn;
            needed += 1;
        }));
        terms.onClick.AddListener((() =>
        {
            terms.image.sprite = termsOn;
            needed += 1;
        }));
        continueButton.onClick.AddListener((() =>
        {
            startGameScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        privacyLink.onClick.AddListener((() =>
        {
            var webView = gameObject.AddComponent<UniWebView>();
            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
            webView.SetShowToolbar(true);
            webView.SetBackButtonEnabled(true);
            webView.Load("https://awiclo.co.uk/privacy/");
            webView.Show();
        }));
        termsLink.onClick.AddListener((() =>
        {
            var webView = gameObject.AddComponent<UniWebView>();
            webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
            webView.SetShowToolbar(true);
            webView.SetBackButtonEnabled(true);
            webView.Load("https://awiclo.co.uk/terms/");
            webView.Show();
        }));
    }

    private void Update()
    {
        if (needed >= 2)
        {
            continueButton.image.sprite = continueButtonOn;
            continueButton.enabled = true;
        }
    }

    private void OnDisable()
    {
        privacy.onClick.RemoveAllListeners();
        terms.onClick.RemoveAllListeners();
        continueButton.onClick.RemoveAllListeners();
        privacyLink.onClick.RemoveAllListeners();
        termsLink.onClick.RemoveAllListeners();
    }
}