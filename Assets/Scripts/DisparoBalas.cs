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

    [Header("Sonidos")]
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip emptySound;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentAmmo < maxAmmo)
            {
                StartCoroutine(Reload());
            }
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("Sin munición");

            if (audioSource != null && emptySound != null)
            {
                audioSource.PlayOneShot(emptySound);
            }

            return;
        }

        currentAmmo--;
        UpdateAmmoUI();

        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log("Le pegaste a: " + hit.collider.name);

            ZombieHealth zombie = hit.collider.GetComponent<ZombieHealth>();

            if (zombie != null)
            {
                zombie.TakeDamage(damage);

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

        if (audioSource != null && reloadSound != null)
        {
            audioSource.PlayOneShot(reloadSound);
        }

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        UpdateAmmoUI();

        isReloading = false;
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo + " / " + maxAmmo;
        }
    }
}

