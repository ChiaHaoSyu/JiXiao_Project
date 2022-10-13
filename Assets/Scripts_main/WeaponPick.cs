using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour
{
    public Transform equipPosition;
    public GameObject weaponInFloor;
    public GameObject currentWeapon;

    public bool canPick;
    public bool canFire;

    private void Update()
    {
        CheakWeapons();

        if(canPick)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeapon != null)
                    Drop();

                PickUp();
            }
        }

        ReadytoFire();

    }


    public void CheakWeapons()
    {
        weaponInFloor = null;
        canPick = false;
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 1);
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Weapon"))
                {
                    weaponInFloor = cols[i].gameObject;
                    canPick = true;
                }
            }
        }

    }

    void PickUp()
    {
        currentWeapon = weaponInFloor;
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localPosition = new Vector3(0, 0, 0);
        currentWeapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
        currentWeapon.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
        currentWeapon.GetComponent<Rigidbody2D>().isKinematic = false;
        currentWeapon = null;
    }

    public void ReadytoFire()
    {
        if (currentWeapon != null)
        {
            canFire = true;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
        }
        else
        {
            canFire = false;
        }
    }

}
