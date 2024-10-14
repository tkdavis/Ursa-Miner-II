using UnityEditor.Experimental.GraphView;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6.0f;
    [SerializeField]
    private float rotateSpeed = 3.0f;

    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 aimDirection;
    private float moveH;
    private float moveV;
    private float aimH;
    private float aimV;
    private Quaternion lastValidRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastValidRotation = transform.rotation;
    }


    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        aimH = Input.GetAxis("RightStickH");
        aimV = Input.GetAxis("RightStickV");
        movement = new Vector3(moveH, 0.0f, moveV).normalized;
        aimDirection = new Vector3(aimH, 0.0f, aimV).normalized;

        if (aimDirection.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(aimDirection.x, -aimDirection.z) * Mathf.Rad2Deg;
            lastValidRotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, lastValidRotation, rotateSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // rb.AddTorque(transform.up * moveH * rotateSpeed, ForceMode.Force);
        rb.AddForce(movement * moveSpeed);
    }
}
