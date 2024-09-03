using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Messaging;

public class FBS : MonoBehaviour
{
    [SerializeField] private WebScreen WebScreen;

    public void Start() 
    {
        if (PlayerPrefs.GetInt("Requested") == 0)
        {
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
                Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
                PlayerPrefs.SetInt("Requested", 1);
                WebScreen.StartWeb();
            });
            WebScreen.StartWeb();
        }
        else
        {
            WebScreen.StartWeb();
        }
    }

    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token) 
    {
        UnityEngine.Debug.Log("Received Registration Token: " + token.Token);
    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e) 
    {
        UnityEngine.Debug.Log("Received a new message from: " + e.Message.From);
    }

    private void OnDisable()
    {
        Firebase.Messaging.FirebaseMessaging.TokenReceived -= OnTokenReceived;
        Firebase.Messaging.FirebaseMessaging.MessageReceived -= OnMessageReceived;
    }

    private void OnDestroy()
    {
        Firebase.Messaging.FirebaseMessaging.TokenReceived -= OnTokenReceived;
        Firebase.Messaging.FirebaseMessaging.MessageReceived -= OnMessageReceived;
    }
}