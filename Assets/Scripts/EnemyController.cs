using UnityEngine;

public enum EnemyState
{
    Patrol,
    Chase,
    Attack,
    Dead
}

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.3f;
    [SerializeField]
    private float avoidanceRadius = 10.0f;
    [SerializeField]
    private float avoidanceBlendFactor = 0.6f;

    private Vector3 movement;
    private Transform targetTransform;
    private Transform playerTransform;
    private Transform capitalShipTransform;
    private Rigidbody rb;
    private EnemyState currentState;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        capitalShipTransform = GameObject.FindGameObjectWithTag("CapitalShip").transform;
        targetTransform = capitalShipTransform;
        rb = GetComponent<Rigidbody>();
        currentState = EnemyState.Patrol;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                targetTransform = capitalShipTransform;
                // behavior here
                break;
            case EnemyState.Chase:
                targetTransform = playerTransform;
                break;
            case EnemyState.Attack:
                // behavior here
                break;
            case EnemyState.Dead:
                // behavior here
                break;
        }

        Vector3 targetDirection = (targetTransform.position - transform.position).normalized;

        Vector3 avoidanceDirection = GetAvoidanceDirection();

        movement = Vector3.Lerp(targetDirection, avoidanceDirection.normalized, avoidanceBlendFactor);
        movement.Normalize();

        movement.y = 0;

        if (movement != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * moveSpeed, ForceMode.VelocityChange);
    }

    private Vector3 GetAvoidanceDirection()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, avoidanceRadius);

        Vector3 avoidanceVector = Vector3.zero;

        foreach (var hit in hits)
        {
            Vector3 directionAway = transform.position - hit.transform.position;
            avoidanceVector += directionAway.normalized / hits.Length;
        }

        return avoidanceVector;
    }
}
