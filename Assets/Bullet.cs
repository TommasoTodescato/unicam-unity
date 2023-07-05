using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    public int shootSpeed;
    private Vector2 move;
    private Rigidbody2D body;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            body.AddForce(transform.up * shootSpeed, ForceMode2D.Impulse);

        move.x = Input.GetAxis("Horizontal");
        if(move.x != 0)
        {
            float xMove = move.x * speed * Time.deltaTime;
            Vector2 newPos = new Vector2(body.position.x + xMove, body.position.y);
            body.MovePosition(newPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        body.velocity = Vector2.zero;
        body.MovePosition(new Vector2(59, -6));
    }
}
