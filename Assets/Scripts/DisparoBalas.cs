using TMPro;
using UnityEngine;

public class DisparoBalas : MonoBehaviour
{
    [Header("Disparo")]
    public Transform firePoint;
    public float range = 100f;
    public int damage = 25;

    [Header("Munición")]
    public int maxAmmo = 30;
    public int currentAmmo;

    public float reloadTime = 2f;
    private bool isReloading = false;

    [Header("UI")]
    public TextMeshProUGUI ammoText;

    [Header("Hitmarker")]
    public Hitmarker hitmarker;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        if (isReloading)
            return;

        // 🔫 Disparar
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        // ♻️ Recargar
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        
        if (currentAmmo <= 0)
        {
            Debug.Log("Sin munición");
            return;
        }

        currentAmmo--;
        UpdateAmmoUI();

        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log("Le pegaste a: " + hit.collider.name);

            ZombieHealth zombie = hit.collider.GetComponent<ZombieHealth>();

            if (zombie != null)
            {
                zombie.TakeDamage(damage);

                // 🎯 Hitmarker
                if (hitmarker != null)
                {
                    hitmarker.ShowHitmarker();
                }
            }
        }
    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Recargando...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        UpdateAmmoUI();

        isReloading = false;
    }

    void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo + " / " + maxAmmo;
    }
}

