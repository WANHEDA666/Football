using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject privacyScreen;
    [SerializeField] private GameObject startGameScreen;
    [SerializeField] private AudioSource audioSource;
    
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
        if (PlayerPrefs.GetInt("PrivacyShown") == 0)
        {
            PlayerPrefs.SetInt("PrivacyShown", 1);
            privacyScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            startGameScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
