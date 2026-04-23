using UnityEngine;

public class DisparoBalas : MonoBehaviour
{
    public Transform firePoint;
    public float range = 100f;
    public int damage = 25;

    public Hitmarker hitmarker; // 👈 referencia al hitmarker

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log("Le pegaste a: " + hit.collider.name);

            ZombieHealth zombie = hit.collider.GetComponent<ZombieHealth>();

            if (zombie != null)
            {
                zombie.TakeDamage(damage);

                // 🔥 activar hitmarker
                if (hitmarker != null)
                {
                    hitmarker.ShowHitmarker();
                }
            }
        }
    }
}

