using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectGame : MonoBehaviour
{
    [SerializeField] private Button back;
    [SerializeField] private Button pingPong;
    [SerializeField] private Button football;
    [SerializeField] private GameObject pingPongScreen;
    [SerializeField] private GameObject footballScreen;
    [SerializeField] private GameObject startScreen;

    private void OnEnable()
    {
        back.onClick.AddListener((() =>
        {
            startScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        pingPong.onClick.AddListener((() =>
        {
            pingPongScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        football.onClick.AddListener((() =>
        {
            footballScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
    }

    private void OnDisable()
    {
        back.onClick.RemoveAllListeners();
        pingPong.onClick.RemoveAllListeners();
        football.onClick.RemoveAllListeners();
    }
}