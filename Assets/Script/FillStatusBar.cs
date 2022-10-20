using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillStatusBar : MonoBehaviour
{
    public int MaxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    
}
