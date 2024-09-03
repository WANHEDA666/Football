using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Football : MonoBehaviour
{
    [SerializeField] private Button pause;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button hit;
    [SerializeField] private Sprite[] boots;
    [SerializeField] private FBall ball;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject boot;
    [SerializeField] private GameObject sc;
    private bool locked;
    private float t;
    
    private FBall fb;
    private GameObject b;
    
    private void OnEnable()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        b = Instantiate(boot, transform);
        b.GetComponent<Image>().sprite = boots[PlayerPrefs.GetInt("boot" + "enabled")];
        fb = Instantiate(ball, transform);
        fb.fail += () =>
        {
            Destroy(fb.gameObject);
            Destroy(b.gameObject);
            startScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        };
        fb.scored += () =>
        {
            PlayerPrefs.SetInt("scoreFootball", PlayerPrefs.GetInt("scoreFootball") + (1 * PlayerPrefs.GetInt("boot" + "x")));
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("scorePingPong") + PlayerPrefs.GetInt("scoreFootball"));
            score.text = PlayerPrefs.GetInt("score").ToString();
            StartCoroutine(gt());
        };
        fb.boot = b.GetComponent<RectTransform>();
        pause.onClick.AddListener((() =>
        {
            fb.Stop();
            pauseScreen.gameObject.SetActive(true);
            pauseScreen.GetComponent<Pause>().disabling += () =>
            {
                fb.StartG();
            };
        }));
        hit.onClick.AddListener((() =>
        {
            if (!locked)
            {
                b.GetComponent<Image>().transform.localRotation = Quaternion.Euler(new Vector3(0,0,-25));
                locked = true;
            }
        }));
    }
    
    IEnumerator gt()
    {
        var s = Instantiate(sc, b.transform);
        yield return new WaitForSeconds(0.35f);
        Destroy(s.gameObject);
    }

    private void Update()
    {
        if (locked)
        {
            t += Time.deltaTime;
            if (t > 0.8f)
            {
                b.GetComponent<Image>().transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
                locked = false;
                t = 0;
            }
        }
    }

    private void OnDisable()
    {
        pause.onClick.RemoveAllListeners();
    }
}