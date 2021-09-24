using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLightOne : MonoBehaviour
{
    private Light lampLightOne;
    private float intensity = 0;
    void Start()
    {
        lampLightOne = GetComponent<Light>();
    }
    private void FixedUpdate()
    {
        if (lampLightOne.intensity < 0.1)
        {
            intensity = (float)(intensity + 0.0001);
            lampLightOne.intensity = intensity;
        }
    }
}
