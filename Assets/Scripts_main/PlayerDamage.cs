using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(FlashRed());
            TakeDamage(10);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(FlashRed());
            TakeDamage(10);
        }
    }

    public IEnumerator FlashRed()
    {
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        playerSprite.color = Color.white;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}
