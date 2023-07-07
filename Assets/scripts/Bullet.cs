using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;

    public Camera screen;
    private Vector2 screenLimits;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        screenLimits = screen.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        body.velocity = transform.up * speed;

        bool isOut =    transform.position.y > screenLimits.y     ||
                        transform.position.y < -screenLimits.y    ||
                        transform.position.x > screenLimits.x     || 
                        transform.position.x < -screenLimits.x;
        if (isOut)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != GameObject.Find("ship"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
