using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShipMovement : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotateSpeed = 3.0f;
    [SerializeField]
    private float fireRate = 0.1f;

    private Rigidbody rb;
    private Vector3 movement;
    private float moveH;
    private float throttle;
    private bool firePressed;
    private float fireRateCooldown;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fireRateCooldown = fireRate;
    }


    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        firePressed = Input.GetButton("Fire1");

        fireRateCooldown -= Time.deltaTime;

        if (firePressed && fireRateCooldown <= 0.0f)
        {
            StartCoroutine("FireWeapons");
            fireRateCooldown = fireRate;
        }
    }

    private void FixedUpdate()
    {
        rb.AddTorque(transform.up * moveH * rotateSpeed, ForceMode.Force);
    }

    private void FireWeapons()
    {
        Instantiate(projectile, transform.forward * 2f, transform.rotation);
    }
}
