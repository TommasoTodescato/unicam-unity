using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pallina : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    bool yMovingOld;

    void Start()
    {
    }

    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        bool xMoving = move.x != 0;
        bool yMoving = move.y != 0;

        if (xMoving && yMoving)
        {
            if (yMovingOld)
                move.y = 0;
            else
                move.x = 0;
        }
        else if (xMoving)
        {
            move.y = 0;
            yMovingOld = false;
        }
        else if (yMoving)
        {
            move.x = 0;
            yMovingOld = true;
        }
        else
        {
            move.x = 0;
            move.y = 0;
        }
        
        transform.Translate(move * speed * Time.deltaTime);
    }
}