using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button back;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button change;
    [SerializeField] private Sprite rockets;
    [SerializeField] private Sprite boots;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject rocketsScroll;
    [SerializeField] private GameObject footballScroll;
    [SerializeField] private ShopItem[] shopItemsPong;
    [SerializeField] private ShopItem[] shopItemsFootball;

    private void OnEnable()
    {
        foreach (var shopItem in shopItemsPong)
        {
            shopItem.onUsed += s =>
            {
                foreach (var shopItem1 in shopItemsPong)
                {
                    if (shopItem1.ID != s)
                    {
                        shopItem1.Disabled();
                    }
                }
            };
        }
        
        foreach (var shopItem in shopItemsFootball)
        {
            shopItem.onUsed += s =>
            {
                foreach (var shopItem1 in shopItemsFootball)
                {
                    if (shopItem1.ID != s)
                    {
                        shopItem1.Disabled();
                    }
                }
            };
        }
        
        back.onClick.AddListener((() =>
        {
            startScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }));
        change.onClick.AddListener((() =>
        {
            if (change.image.sprite == rockets)
            {
                change.image.sprite = boots;
                footballScroll.gameObject.SetActive(true);
                rocketsScroll.gameObject.SetActive(false);
            }
            else
            {
                change.image.sprite = rockets;
                footballScroll.gameObject.SetActive(false);
                rocketsScroll.gameObject.SetActive(true);
            }
        }));
    }

    private void Update()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
    }

    private void OnDisable()
    {
        back.onClick.RemoveAllListeners();
        change.onClick.RemoveAllListeners();
        foreach (var shopItem in shopItemsPong)
        {
            shopItem.onUsed -= s =>
            {
                foreach (var shopItem1 in shopItemsPong)
                {
                    if (shopItem1.ID != s)
                    {
                        shopItem1.Disabled();
                    }
                }
            };
        }
        
        foreach (var shopItem in shopItemsFootball)
        {
            shopItem.onUsed -= s =>
            {
                foreach (var shopItem1 in shopItemsFootball)
                {
                    if (shopItem1.ID != s)
                    {
                        shopItem1.Disabled();
                    }
                }
            };
        }
    }
}