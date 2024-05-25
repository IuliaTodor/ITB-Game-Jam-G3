using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int totalBullets;
    public int bulletsLeft;
    public float bulletSpeed;

    public PlayerMovement playerMovement;

    public Transform shootPoint;
    public Transform bulletPrefab;

    [SerializeField] private WeaponCooldown cooldown;


    private void Awake()
    {
        bulletsLeft = totalBullets;
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Start()
    {
        UIManager.instance.UpdatePlayerHealth(bulletsLeft, totalBullets);
    }
    private void FixedUpdate()
    {
        if (cooldown.isCoolingDown)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletsLeft > 0)
        {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, playerMovement.transform.rotation);

            cooldown.StartCooldown();

            bullet.GetComponent<Rigidbody>().velocity = shootPoint.forward * (bulletSpeed + playerMovement.speed);

            bulletsLeft--;

            UIManager.instance.UpdatePlayerHealth(bulletsLeft, totalBullets);
        }

        else
        {
            Debug.Log("No quedan balas");
        }
    }

    public void Reload()
    {
        Debug.Log("Reload");
        bulletsLeft = totalBullets;
        UIManager.instance.UpdatePlayerHealth(bulletsLeft, totalBullets);
    }


}
