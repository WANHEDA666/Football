using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PingPong : MonoBehaviour
{
    [SerializeField] private Button pause;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button left;
    [SerializeField] private Button right;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Sprite[] rockets;
    [SerializeField] private Ball ball;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject rocket;
    [SerializeField] private GameObject sc;
    [SerializeField] private AudioSource audioSource;

    private Ball b;
    private GameObject r;

    private void OnEnable()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        r = Instantiate(rocket, transform);
        r.GetComponent<Image>().sprite = rockets[PlayerPrefs.GetInt("rocket" + "enabled")];
        b = Instantiate(ball, transform);
        b.fail += () =>
        {
            Destroy(b.gameObject);
            Destroy(r.gameObject);
            startScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        };
        b.scored += () =>
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            audioSource.Play();
            PlayerPrefs.SetInt("scorePingPong", PlayerPrefs.GetInt("scorePingPong") + (1 * PlayerPrefs.GetInt("rocket" + "x")));
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("scorePingPong") + PlayerPrefs.GetInt("scoreFootball"));
            score.text = PlayerPrefs.GetInt("score").ToString();
            StartCoroutine(gt());
        };
        b.rocket = r.GetComponent<RectTransform>();
        pause.onClick.AddListener((() =>
        {
            b.Stop();
            pauseScreen.gameObject.SetActive(true);
            pauseScreen.GetComponent<Pause>().disabling += () =>
            {
                b.StartG();
            };
        }));
        left.onClick.AddListener((() =>
        {
            if (r.GetComponent<RectTransform>().anchoredPosition.x > -650)
            {
                r.GetComponent<RectTransform>().anchoredPosition = new Vector2(r.GetComponent<RectTransform>().anchoredPosition.x - 40, r.GetComponent<RectTransform>().anchoredPosition.y);
            }
        }));
        right.onClick.AddListener((() =>
        {
            if (r.GetComponent<RectTransform>().anchoredPosition.x < 650)
            {
                r.GetComponent<RectTransform>().anchoredPosition = new Vector2(r.GetComponent<RectTransform>().anchoredPosition.x + 40, r.GetComponent<RectTransform>().anchoredPosition.y);
            }
        }));
    }

    private void OnDisable()
    {
        Destroy(b.gameObject);
        Destroy(r.gameObject);
        pause.onClick.RemoveAllListeners();
        left.onClick.RemoveAllListeners();
        right.onClick.RemoveAllListeners();
    }
    
    IEnumerator gt()
    {
        var s = Instantiate(sc, r.transform);
        yield return new WaitForSeconds(0.35f);
        Destroy(s.gameObject);
    }
}