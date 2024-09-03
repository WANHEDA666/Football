using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button settings;
    [SerializeField] private Button shop;
    [SerializeField] private Button start;
    [SerializeField] private Button statistics;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject shopScreen;
    [SerializeField] private GameObject selectGameScreen;
    [SerializeField] private GameObject statisticsScreen;
    [SerializeField] private GameObject privacyScreen;
    
    private void OnEnable()
    {
        privacyScreen.SetActive(false);
        settings.onClick.AddListener((() =>
        {
            settingsScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        shop.onClick.AddListener((() =>
        {
            shopScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        start.onClick.AddListener((() =>
        {
            selectGameScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        statistics.onClick.AddListener((() =>
        {
            statisticsScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
    }

    private void OnDisable()
    {
        settings.onClick.RemoveAllListeners();
        shop.onClick.RemoveAllListeners();
        start.onClick.RemoveAllListeners();
        statistics.onClick.RemoveAllListeners();
    }
}