using System;
using UnityEngine;

public class FBall : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RectTransform bal;
    private bool failed;
    public Action fail;
    public Action scored;
    public RectTransform boot;
    
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
        rb.velocity = new Vector2(0, speed);
    }
    
    private void FixedUpdate()
    {
        if (bal.anchoredPosition.y < -600 && !failed)
        {
            if (boot.rotation.eulerAngles.magnitude < 300)
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