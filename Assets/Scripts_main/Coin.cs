using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            playerMovement.coins += Random.Range(3, 9);

            Destroy(this.gameObject);
        }
    }
}
