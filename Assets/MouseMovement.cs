using UnityEngine;

public class MouseMove2D : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 mousePosition;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            Vector3 targetPosition = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

            rigidbody.MovePosition(targetPosition);
        }
    }
}