using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : Interaction
{
    public PlayerDamage playerDamage;
    public HealthBar healthBar;

    protected override void OnPlayerInteractEvent()
    {
        playerDamage.currentHealth += 20;
        healthBar.SetHealth(playerDamage.currentHealth);
    }

}
