using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearLightening : MonoBehaviour
{

    public bool bearMove = false;
    private float upDiff;
    private Vector3 bearPosition;

    private float intensity = 1.5f;
    private bool lightEnabled = false;

    private void Start()
    {
        bearPosition = transform.position;
    }
    private void FixedUpdate()
    {
        upDiff = transform.position.y - bearPosition.y;
        if (Mathf.Abs(upDiff) > 0.1 )
        {

            bearMove = true;
        }
    }
}
