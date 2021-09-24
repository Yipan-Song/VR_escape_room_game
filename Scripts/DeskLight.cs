using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLight : MonoBehaviour
{
    private Light deskLight;
    private float intensity = 0;
    void Start()
    {
        deskLight = GetComponent<Light>();
    }
    private void FixedUpdate()
    {
        if (deskLight.intensity < 0.1)
        {
            intensity = (float)(intensity + 0.0001);
            deskLight.intensity = intensity;
        }
    }
}
