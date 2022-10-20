using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotting : MonoBehaviour
{
    public Animator anim;
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
            if(wp.currentWeapon.name.Contains("bursh"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    AttackLooking();
                    InvokeRepeating("Shoot", delayTime, shotRate);
                }
                else if(Input.GetButtonUp("Fire1"))
                {
                    anim.SetBool("isAttackingL", false);
                    anim.SetBool("isAttackingR", false);
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

    void AttackLooking()
    {
        if (GetComponent<SpriteRenderer>().flipY == true)
        {
            anim.SetBool("isAttackingL", true);
        }
        else
        {
            anim.SetBool("isAttackingR", true);
        }
    }

}
