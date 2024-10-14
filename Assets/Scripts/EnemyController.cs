using System;
using UnityEditor.Callbacks;
using UnityEngine;

public enum EnemyState
{
    Patrol,
    Chase,
    Attack,
    Avoid,
    Dead
}

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6.0f;

    private Vector3 movement;
    private EnemyState currentState;
    private Transform targetTransform;
    private Transform playerTransform;
    private Rigidbody rb;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = EnemyState.Chase;
        targetTransform = playerTransform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                // behavior here
                break;
            case EnemyState.Chase:
                movement = (targetTransform.position - transform.position).normalized;
                break;
            case EnemyState.Attack:
                // behavior here
                break;
            case EnemyState.Avoid:
                // behavior here
                break;
            case EnemyState.Dead:
                // behavior here
                break;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * moveSpeed);
    }
}
