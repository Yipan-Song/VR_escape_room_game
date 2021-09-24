using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public GameObject promptThree;
    public GameObject promtFour;
    public GameObject deskAnchor;
    public GameObject bedAnchor;
    public GameObject deskCollider;
    public GameObject promtThree;
    public bool promptThreeIfShow = true;
    public GameObject promptTen;
    public bool doorSoundWork = false;
    private AudioSource playingSoundDoor;
    private AudioSource SoundOnePlaying;
    private AudioSource SoundTwoPlaying;
    private bool doorSound = true;
    private PiggyBankVoiceOver piggyBankVoiceOver;
    private bool piggyBankSound = false;
    // Start is called before the first frame update
    void Start()
    {
        SoundOnePlaying = transform.parent.Find("Narrative 1").gameObject.GetComponent<AudioSource>();
        SoundTwoPlaying = transform.parent.Find("Narrative 2").gameObject.GetComponent<AudioSource>();
        playingSoundDoor = GetComponent<AudioSource>();
        piggyBankVoiceOver = GameObject.FindObjectOfType<PiggyBankVoiceOver>();

    }
    private void Update()
    {
        piggyBankSound = piggyBankVoiceOver.IfpiggyBankVoiceWork;
        if (piggyBankSound)
        {
            playingSoundDoor.Stop();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("door trigger :: " + other.name);

        
        if (other.name == "XR Rig"  && doorSound)
        {
            Debug.Log("Door Sound Play");
            promptThreeIfShow = false;
            SoundOnePlaying.Stop();
            SoundTwoPlaying.Stop();
            playingSoundDoor.Play();
            doorSoundWork = true;
            doorSound = false;
            promptThree.SetActive(false);
            promtFour.SetActive(true);
            bedAnchor.SetActive(false);
            deskAnchor.SetActive(true);
            deskCollider.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("door trigger exit:: " + other.name);

        if (other.name == "XR Rig")
        {
            Debug.Log("player exit the door");
            promtFour.SetActive(false);
            promptTen.SetActive(false);
        }
    }
}
