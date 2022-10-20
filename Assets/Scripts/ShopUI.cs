using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject shop;
    public bool playerInRange;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (shop.activeInHierarchy)
            {
                shop.SetActive(false);
            }
            else
            {
                shop.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            shop.SetActive(false);
        }
    }
}
