using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce = 25f;
    public float shotRate;
    public float delayTime;

    public WeaponPick wp;


    void Update()
    {
        if(wp.canFire)
        {
            if(wp.currentWeapon.name.Contains("weaponTest"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    InvokeRepeating("Shoot", delayTime, shotRate);
                }
                else if(Input.GetButtonUp("Fire1"))
                {
                    CancelInvoke("Shoot");
                }    
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

}
