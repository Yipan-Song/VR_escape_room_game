using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayKeys : MonoBehaviour
{
    private bool putKey1 = false;
    private bool putKey2 = false;
    private bool putKey3 = false;

    public GameObject doorHandle;
    public GameObject fader;


    public GameObject promptNine;
    public GameObject promptThirteen;

    public GameObject doorAnchor;
    public GameObject bedAnchor;

    public bool checkSecondKeyinLock = false;
    public bool letpromptThreeShow = true;


    private AudioSource keySound;

    private void Start()
    {
        keySound = transform.GetChild(3).gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Key 1")
        {
            putKey1 = true;
            transform.GetChild(0).gameObject.SetActive(true);
            keySound.Play();
            Destroy(other);
        }
        if (other.tag == "Key 2")
        {
            putKey2 = true;
            transform.GetChild(1).gameObject.SetActive(true);
            keySound.Play();
            Destroy(other);
            Destroy(promptNine);
            checkSecondKeyinLock = true;
            doorAnchor.SetActive(false);
            bedAnchor.SetActive(true);
        }
        if (other.tag == "Key 3")
        {
            putKey3 = true;
            transform.GetChild(2).gameObject.SetActive(true);
            keySound.Play();
            Destroy(other);
            Destroy(promptThirteen);
            letpromptThreeShow = false;
            Debug.Log("three keys bool :: " + putKey1 + putKey2 + putKey3);
            if(putKey1 && putKey2 && putKey3)
            {
                doorHandle.SetActive(true);
                fader.SetActive(true);
            }
        }
    }
}
