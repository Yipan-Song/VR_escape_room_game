using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookcaseSpotLight : MonoBehaviour
{
    private Light bookcaseSpotLight;
    private float intensity = 0;
    void Start()
    {
        bookcaseSpotLight = GetComponent<Light>();
    }
    private void FixedUpdate()
    {
        if (bookcaseSpotLight.intensity < 0.6)
        {
            intensity = (float)(intensity + 0.0002);
            bookcaseSpotLight.intensity = intensity;
        }
    }
}
