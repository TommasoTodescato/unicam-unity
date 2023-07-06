using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public int speed;
    private Vector2 move;
    private Rigidbody2D body;

    public GameObject bulletPrefab;

    private bool canShoot = true;
    private float cooldown = 0.3f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move.x = (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        if (move.x != 0)
        {
            Vector2 newPos = new Vector2(body.position.x + move.x, body.position.y);
            body.MovePosition(newPos);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Vector2 bulletPos = new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2);
            GameObject bullet = Instantiate(bulletPrefab, bulletPos, transform.rotation);

            bullet.transform.parent = transform.parent;

            StartCoroutine(reload());
        }
    }

    System.Collections.IEnumerator reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}