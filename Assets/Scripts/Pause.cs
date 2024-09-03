using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button startScreenButton;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject pingPongScreen;
    [SerializeField] private GameObject footballScreen;
    public Action disabling;

    private void OnEnable()
    {
        
        continueButton.onClick.AddListener((() =>
        {
            disabling.Invoke();
            gameObject.SetActive(false);
        }));
        startScreenButton.onClick.AddListener((() =>
        {
            startScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
            pingPongScreen.SetActive(false);
            footballScreen.SetActive(false);
        }));
    }

    private void Update()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveAllListeners();
        startScreenButton.onClick.RemoveAllListeners();
    }
}