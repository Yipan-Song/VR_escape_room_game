using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGeneration : MonoBehaviour
{
    public GameObject key;

    private GameObject playS1L5;
    private GameObject playS2L1;
    private GameObject playS2L2;

    public GameObject bookcaseCollider;
    public GameObject droppedBook;

    public GameObject promptSix;
    public GameObject promptSeven;
    public GameObject deskAnchor;
    public GameObject bookshelfAnchor;

    public bool gotoBookCase = false;
    public bool firstKeySound = false;

    private Quaternion rotationAngle;
    private bool keyShow = true;
    private bool letBookDrop = true;
    private AudioSource playBookDropSound;

    private void Start()
    {
        playS1L5 = transform.GetChild(0).gameObject;
        playS2L1 = transform.GetChild(2).gameObject;
        playS2L2 = transform.GetChild(3).gameObject;
        playBookDropSound = transform.GetChild(4).gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationAngle = transform.rotation;
  
        if (transform.up.y < 0f && keyShow)
        {
            Instantiate(key, transform.position, transform.rotation).SetActive(true);

            promptSix.SetActive(true);

            deskAnchor.SetActive(false);

            playS1L5.SetActive(true);
            firstKeySound = true;

            Invoke("playSceneTwoLineOne", 8.0f);

           keyShow = false;
        }
    }

    void playSceneTwoLineOne() 
    {
        playS1L5.SetActive(false);
        promptSix.SetActive(false);
        playS2L1.SetActive(true);
        Invoke("playSceneTwoLineTwo", 6.0f);
    }

    void playSceneTwoLineTwo() 
    {
        playS2L1.SetActive(false);
        playS2L2.SetActive(true);
        Invoke("playSceneTwoLineThree", 16.0f);
    }

    void playSceneTwoLineThree()
    {        
        if (letBookDrop)
        {
            playBookDropSound.Play();
            droppedBook.GetComponent<Rigidbody>().AddForce(0.5f, 0, 0, ForceMode.Impulse);
            promptSeven.SetActive(true);
            bookshelfAnchor.SetActive(true);
            letBookDrop = false;
            gotoBookCase = true;
        }
    }

}
