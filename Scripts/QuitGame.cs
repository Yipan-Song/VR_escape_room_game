using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void DoExitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}

