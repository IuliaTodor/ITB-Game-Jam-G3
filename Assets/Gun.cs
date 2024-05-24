using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int totalBullets;
    public int bulletsLeft;

    public Transform shootPoint;
    public Transform bulletPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletsLeft > 0)
        {
            Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bulletsLeft--;
        }
    }


}
