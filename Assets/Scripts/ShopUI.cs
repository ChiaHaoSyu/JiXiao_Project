using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : Interaction
{
    public GameObject shop;

    protected override void OnPlayerInteractEvent()
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
