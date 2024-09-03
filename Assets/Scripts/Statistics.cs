using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    [SerializeField] private Button back;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private TextMeshProUGUI pingPong;
    [SerializeField] private TextMeshProUGUI football;

    private void OnEnable()
    {
        back.onClick.AddListener((() =>
        {
            startScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        pingPong.text = PlayerPrefs.GetInt("scorePingPong").ToString();
        football.text = PlayerPrefs.GetInt("scoreFootball").ToString();
    }

    private void OnDisable()
    {
        back.onClick.RemoveAllListeners();
    }
}