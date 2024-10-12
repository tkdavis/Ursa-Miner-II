using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float startSpeed = 6.0f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * startSpeed, ForceMode.Impulse);
    }
}
