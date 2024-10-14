using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float startSpeed = 12.0f;
    [SerializeField]
    private float lifeTime = 6.0f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * startSpeed, ForceMode.Impulse);
        Destroy(gameObject, lifeTime);
    }
}
