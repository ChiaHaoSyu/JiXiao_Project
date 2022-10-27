using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public bool playerInRange;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            OnPlayerInteractEvent();
        }

    }

    protected virtual void OnPlayerEnterEvent() { }
    protected virtual void OnPlayerExitEvent() { }
    protected virtual void OnPlayerInteractEvent() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            OnPlayerEnterEvent();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            OnPlayerExitEvent();
        }
    }
}
