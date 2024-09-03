using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private GameObject purchased;
    [SerializeField] private GameObject price;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button useButton;
    [SerializeField] private GameObject used;
    [SerializeField] private int isprice;
    [SerializeField] private int isx;
    [SerializeField] private string name;
    [SerializeField] private int id;

    public Action<int> onUsed;

    public int ID => id;

    public void Disabled()
    {
        if (PlayerPrefs.GetInt(name + id) == 1)
        {
            price.gameObject.SetActive(false);
            purchased.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            used.gameObject.SetActive(false);
            useButton.gameObject.SetActive(true);
        }
        else
        {
            price.gameObject.SetActive(true);
            purchased.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(name + id) == 1)
        {
            price.gameObject.SetActive(false);
            purchased.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt(name + "enabled") == id)
            {
                used.gameObject.SetActive(true);
                useButton.gameObject.SetActive(false);
            }
            else
            {
                used.gameObject.SetActive(false);
                useButton.gameObject.SetActive(true);
            }
        }
        else
        {
            price.gameObject.SetActive(true);
            purchased.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
        }
        useButton.onClick.AddListener((() =>
        {
            used.gameObject.SetActive(true);
            useButton.gameObject.SetActive(false);
            PlayerPrefs.SetInt(name + "enabled", id);
            PlayerPrefs.SetInt(name + "x", isx);
            onUsed.Invoke(id);
        }));
        buyButton.onClick.AddListener((() =>
        {
            if (PlayerPrefs.GetInt("score") >= isprice)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - isprice);
                PlayerPrefs.SetInt(name + id, 1);
                buyButton.gameObject.SetActive(false);
                useButton.gameObject.SetActive(true);
                price.gameObject.SetActive(false);
                purchased.gameObject.SetActive(true);
            }
        }));
    }

    private void OnDisable()
    {
        useButton.onClick.RemoveAllListeners();
        buyButton.onClick.RemoveAllListeners();
    }
}