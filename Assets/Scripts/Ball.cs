using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RectTransform bal;

    public RectTransform rocket;
    private bool failed;
    public Action fail;
    public Action scored;

    public void Stop()
    {
        rb.simulated = false;
    }

    public void StartG()
    {
        rb.simulated = true;
    }

    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -0.5f : 0.5f;
        if (bal.anchoredPosition.x < -400)
        {
            x = 0.5f;
        }
        else if (bal.anchoredPosition.x > 400)
        {
            x = -0.5f;
        }
        rb.velocity = new Vector2(x, speed);
    }

    private void FixedUpdate()
    {
        if (bal.anchoredPosition.y < -400 && !failed)
        {
            if (bal.anchoredPosition.x > rocket.anchoredPosition.x && bal.anchoredPosition.x - rocket.anchoredPosition.x > 300)
            {
                failed = true;
                fail.Invoke();
            }
            else if (bal.anchoredPosition.x < rocket.anchoredPosition.x && rocket.anchoredPosition.x - bal.anchoredPosition.x > 300)
            {
                failed = true;
                fail.Invoke();
            }
            else
            {
                LaunchBall(); 
                scored.Invoke();
            }
        }
    }

}