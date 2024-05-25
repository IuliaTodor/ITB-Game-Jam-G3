using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int totalBullets;
    public int bulletsLeft;
    public float bulletSpeed = 2f;

    public PlayerMovement playerMovement;

    public Transform shootPoint;
    public Transform bulletPrefab;

    [SerializeField] private WeaponCooldown cooldown; 


    private void Awake()
    {
        bulletsLeft = totalBullets;
        playerMovement = GetComponentInParent<PlayerMovement>();
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

        Reload();
    }

    public void Shoot()
    {
        if (bulletsLeft > 0)
        {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, playerMovement.transform.rotation);

            cooldown.StartCooldown();

            bullet.GetComponent<Rigidbody>().velocity = shootPoint.forward * (bulletSpeed + playerMovement.speed);

            bulletsLeft--;
        }

        else
        {
            Debug.Log("No quedan balas");
        }
    }

    public void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reload");
            bulletsLeft = totalBullets;
        }
    }


}
