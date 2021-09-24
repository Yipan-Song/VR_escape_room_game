using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookcaseEvent : MonoBehaviour
{
    public GameObject promptEight;

    private AudioSource infrontofBookCase;
    private GameObject hintVoiceFirst;
    private GameObject hintVoiceSecond;
    private bool bookcaseVoice = true;
    private KeyGeneration keygeneration;
    private bool gotoTheBookCase = false;
    public GameObject promptSeven;
    // Start is called before the first frame update
    void Start()
    {
        infrontofBookCase = GetComponent<AudioSource>();
        hintVoiceFirst = transform.GetChild(0).gameObject;
        hintVoiceSecond = transform.GetChild(1).gameObject;
        keygeneration = GameObject.FindObjectOfType<KeyGeneration>();
    }
    private void Update()
    {
        gotoTheBookCase = keygeneration.gotoBookCase;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Book Case trigger :: " + other.name);
        Debug.Log("gotoTheBookCase :: " + gotoTheBookCase);


        if (other.name == "XR Rig" && bookcaseVoice && gotoTheBookCase)
        {
            promptSeven.SetActive(false);
            Debug.Log("book drop and go to bookcase");
            infrontofBookCase.Play();
            bookcaseVoice = false;
            promptEight.SetActive(true);
            Invoke("disablePrompt", 5.0f);
            Invoke("hintVoiceFir", 20.0f);
            gotoTheBookCase = false;
        }
    }

    void hintVoiceFir()
    {
        hintVoiceFirst.SetActive(true);
        Invoke("hintVoiceSec", 15.0f);
    }
    void hintVoiceSec() {
        hintVoiceFirst.SetActive(false);
        hintVoiceSecond.SetActive(true);
        Invoke("disableBookshelfHint", 15.0f);
    }
    void disableBookshelfHint() {
        gameObject.SetActive(false);
        Debug.Log("Disabled: " + gameObject.name);
    }

    void disablePrompt()
    {
        promptEight.SetActive(false);
    }
}
