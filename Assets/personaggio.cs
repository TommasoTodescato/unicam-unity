using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pallina : MonoBehaviour
{
    public float speed;
    private float xInput, yInput;

    void Start()
    {
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        transform.Translate(translation:Vector3.right * (speed * Time.deltaTime * xInput));
        yInput = Input.GetAxis("Vertical");
        transform.Translate(translation: Vector3.up * (speed * Time.deltaTime * yInput));

    }
}
