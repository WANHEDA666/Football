using System;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using UnityEngine;

public class WebScreen : MonoBehaviour
{
    [SerializeField] private Loading _buttonsController;
    private UniWebView webView;

    public void StartWeb()
    {
        if (PlayerPrefs.GetInt("addedURL") == 0)
        {
            var fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAndActivateAsync();
            fetchTask.ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
                    var configData = remoteConfig.GetValue("registerUser").StringValue;
                    PlayerPrefs.SetInt("addedURL", 1);
                    if (configData != "")
                    {
                        webView = gameObject.AddComponent<UniWebView>();
                        webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
                        webView.SetContentInsetAdjustmentBehavior(UniWebViewContentInsetAdjustmentBehavior.Automatic);
                        webView.Load(configData);
                        webView.Show();
                    }
                    else
                    {
                        _buttonsController.StartGame();
                    }
                    PlayerPrefs.SetString("URL", configData);
                }
                else
                {
                    _buttonsController.StartGame();
                }
            });
        }
        else
        {
            if (PlayerPrefs.GetString("URL") != "")
            {
                webView = gameObject.AddComponent<UniWebView>();
                webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
                webView.SetContentInsetAdjustmentBehavior(UniWebViewContentInsetAdjustmentBehavior.Automatic);
                webView.Load(PlayerPrefs.GetString("URL"));
                webView.Show();
            }
            else
            {
                _buttonsController.StartGame();
            }
        }
    }
}