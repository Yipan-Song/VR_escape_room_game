using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLightTwo : MonoBehaviour
{
    private Light lampLightTwo;
    private float intensity = 0;
    void Start()
    {
        lampLightTwo = GetComponent<Light>();
    }
    private void FixedUpdate()
    {
        if (lampLightTwo.intensity < 0.003)
        {
            intensity = (float)(intensity + 0.000001);
            lampLightTwo.intensity = intensity;
        }
    }
}
