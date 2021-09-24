using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S1ToS2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Switching", 25.0f);
    }

    void Switching()
    {
        SceneManager.LoadScene(1);
    }
}
