using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public int speed;
    private Vector2 move;
    private Rigidbody2D body;

    public GameObject bulletPrefab;
    public GameObject superBulletPrefab;

    private float cooldown = 0.4f;
    private float superCooldown = 5.0f;
    private bool canShoot = true, canSuper = true;

    public int life = 3;

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

        if (Input.GetKeyDown(KeyCode.F) && canSuper)
        {
            Vector2 superBulletPos = new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2);
            GameObject superBullet = Instantiate(superBulletPrefab, superBulletPos, transform.rotation);

            superBullet.transform.parent = transform.parent;

            StartCoroutine(superReload());
        }

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (canSuper)
            renderer.color = Color.yellow;
        else
            renderer.color = Color.white;

    }

    System.Collections.IEnumerator reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    System.Collections.IEnumerator superReload()
    {
        canSuper = false;
        yield return new WaitForSeconds(superCooldown);
        canSuper = true;
    }
}