using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject image;
    public bool playerInRange;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if(image.activeInHierarchy)
            {
                image.SetActive(false);
            }
            else
            {
                image.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            image.SetActive(false);
        }
    }
}
