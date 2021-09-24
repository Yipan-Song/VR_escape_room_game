using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchingSceneToEpilogue : MonoBehaviour
{
    private void Start()
    {
        Invoke("Switching", 1.0f);
    }

    void Switching()
    {
        SceneManager.LoadScene(2);
    }
}
