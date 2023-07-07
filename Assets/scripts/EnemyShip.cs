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

    private float reloadTime;
    private bool canShoot;
    public bool forceCanShoot;

    public GameObject enemyBulletPrefab;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        screenLimits = screen.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        reloadTime = Random.Range(2.0f, 10.0f);
        StartCoroutine(reload());
    }

    void Update()
    {
        move.x = speed;
        Vector2 newPos = new Vector2(body.position.x + move.x, body.position.y);
        bool isOut = transform.position.x > screenLimits.x + 40 || transform.position.x < -screenLimits.x - 4;
        
        if (isOut)
            newPos = new Vector2(-screenLimits.x - 4 + 0.5f, body.position.y - 2.0f);

        body.MovePosition(newPos);

        if (canShoot && forceCanShoot)
        {
            Vector2 bulletPos = new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2);
            GameObject bullet = Instantiate(enemyBulletPrefab, bulletPos, transform.rotation);

            bullet.transform.parent = transform.parent;

            StartCoroutine(reload());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("ship"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject == GameObject.Find("superBullet"))
            Destroy(gameObject);
    }

    System.Collections.IEnumerator reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}