using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;

    public Camera screen;
    private Vector3 screenLimits;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        screenLimits = screen.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, screen.transform.position.z));
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
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
