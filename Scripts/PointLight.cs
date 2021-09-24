using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLight : MonoBehaviour
{
    private Light pointLight;
    private float intensity = 0;
    void Start()
    {
        pointLight = GetComponent<Light>();
    }
    private void FixedUpdate()
    {
        if (pointLight.intensity < 2)
        {
            intensity = (float)(intensity + 0.001);
            pointLight.intensity = intensity;
        }
    }
}
