using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public float speed;
    private Vector2 move;

    void Start()
    {
    }

    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        move = move.normalized;

        transform.Translate(move * speed * Time.deltaTime);
    }
}