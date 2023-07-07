using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//      TO KEEP FOR ANIMATION   //

// bool yMovingOld;

//bool xMoving = move.x != 0;
//bool yMoving = move.y != 0;

//if (xMoving && yMoving)
//{
//    if (yMovingOld)
//        move.y = 0;
//    else
//        move.x = 0;
//}
//else if (xMoving)
//{
//    move.y = 0;
//    yMovingOld = false;
//}
//else if (yMoving)
//{
//    move.x = 0;
//    yMovingOld = true;
//}
//else
//{
//    move.x = 0;
//    move.y = 0;
//}


public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector2 move;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move.x = (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        move.y = (Input.GetAxis("Vertical") * speed * Time.deltaTime);
        if (move.x != 0 || move.y != 0)
        {
            Vector2 newPos = new Vector2(body.position.x + move.x, body.position.y + move.y);
            body.MovePosition(newPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("spaceships");
    }
}