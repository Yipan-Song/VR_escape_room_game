using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffFader : MonoBehaviour
{
    public GameObject fader;
    // Start is called before the first frame update
    void Start()
    {
        fader.SetActive(false);
        fader.SetActive(false);
    }
}
