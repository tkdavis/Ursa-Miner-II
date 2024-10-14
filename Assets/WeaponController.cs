using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject projectile;
    [SerializeField]
    private float fireRate = 0.1f;
    private bool firePressed;
    private float fireRateCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireRateCooldown = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        firePressed = Input.GetButton("Fire1");

        fireRateCooldown -= Time.deltaTime;

        if (firePressed && fireRateCooldown <= 0.0f)
        {
            FireWeapons();
            fireRateCooldown = fireRate;
        }
    }

    private void FireWeapons()
    {
        // Vector3 projectileRotation = new Vector3(90.0f, transform.rotation.y, transform.rotation.z);
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
