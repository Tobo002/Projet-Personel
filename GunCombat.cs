using UnityEngine;

public class GunCombat : MonoBehaviour
{

    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float shootSpeed = 0.1f;
    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false;
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Invoke(nameof(ResetCooldown), shootSpeed);
    }

    private void ResetCooldown()
    {
        canShoot = true;
    }
}
