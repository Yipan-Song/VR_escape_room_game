using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key3 : MonoBehaviour
{
    public GameObject bedAnchor;
    public GameObject deskAnchor;
    private Vector3 keyPosition;
    private float upDiff;
    private bool ifKey3VoicePlay = false;
    private AudioSource key3Voice;

    public GameObject afterPickKeySound;
    public GameObject doorLight;
    public bool mainLight = true;
    // Start is called before the first frame update
    void Start()
    {
        keyPosition = transform.position;
        upDiff = 0;
        Debug.Log("keyposition :: " + keyPosition);
        key3Voice = GetComponent<AudioSource>();
        bedAnchor.SetActive(false);
        deskAnchor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        upDiff = transform.position.y - keyPosition.y;
        Debug.Log("upDiff : " + upDiff);
        if (upDiff > 0.2 && !ifKey3VoicePlay)
        {
            afterPickKeySound.SetActive(true);
            ifKey3VoicePlay = true;
            Invoke("turn_off", 20.0f);
            Debug.Log("pick the key3");
        }

    }
    void turn_off()
    {
        doorLight.SetActive(true);
        mainLight = false;
        Debug.Log("end light");
    }
}
