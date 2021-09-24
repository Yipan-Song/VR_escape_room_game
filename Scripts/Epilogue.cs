using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Epilogue : MonoBehaviour
{
    private AudioSource playingSound;
    private AudioSource playingSoundSec;
    private AudioSource playingSoundBetween;
    private AudioSource playingSoundFourth;
    bool betweenClip = true;
    bool firstClip = false;
    bool secondClip = true;
    bool fourthClip = true;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("firstClipplay", 2.0f);
        playingSound = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        playingSoundSec = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        playingSoundBetween = transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        playingSoundFourth = transform.GetChild(3).gameObject.GetComponent<AudioSource>();
    }

    void firstClipplay()
    {
        playingSound.Play();
        Invoke("secondClipPlay", 3.0f);
    }

    void secondClipPlay()
    {
        playingSoundSec.Play();
        Invoke("thirdClipPlay", 3.0f);
    }

    void thirdClipPlay()
    {
        playingSoundBetween.Play();
        Invoke("fourthClipPlay", 6.0f);
    }
    void fourthClipPlay()
    {
        playingSoundFourth.Play();
    }
}
