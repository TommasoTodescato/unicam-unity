using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed;
    private Vector2 move;
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
        move.x = speed;
        Vector2 newPos = new Vector2(body.position.x + move.x, body.position.y);
        bool isOut = transform.position.x > screenLimits.x + 40 || transform.position.x < -screenLimits.x;
        
        if (isOut)
            newPos = new Vector2(-screenLimits.x + 0.5f, body.position.y - 2.0f);

        body.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}