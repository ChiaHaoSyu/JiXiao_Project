using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int minDmg = 2;
    public int maxDmg = 4;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);

            if(collision.gameObject.TryGetComponent<EnemyDamage>(out EnemyDamage enemyComponent))
            {
                enemyComponent.TakeDamage(Random.Range(minDmg,maxDmg));
            }
        }
    }
}
