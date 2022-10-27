using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Interaction
{
    protected override void OnPlayerInteractEvent()
    {
        MoveScene();
    }

    public void MoveScene()
    {
        SceneManager.LoadScene(0);
    } 

}
