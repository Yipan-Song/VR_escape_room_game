using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PrologueAudio : MonoBehaviour
{
    private AudioSource playingSound;
    private AudioSource playingSoundSec;
    private AudioSource playingSoundBetween;
    bool betweenClip = true;
    bool firstClip = false;
    bool implusePlay = true;
    bool secondClip = true;
    private InputDevice leftHand;
    private InputDevice rightHand;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        Invoke("firstClipplay", 2.0f);
        playingSound = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        playingSoundSec = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        playingSoundBetween = transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);
        foreach (var device in inputDevices)
        {
            if (device.role.ToString() == "LeftHanded")
            {
                leftHand = device;
            }
            else if (device.role.ToString() == "RightHanded")
            {
                rightHand = device;
            }
        }
    }

    void firstClipplay()
    {
        playingSound.Play();
        firstClip = true;
    }
    // Update is called once per frame
    void Update()
    {
        while (!playingSound.isPlaying && betweenClip && firstClip)
        { 

            playingSoundBetween.Play();
            betweenClip = false;
        }
        while (!playingSoundBetween.isPlaying && !betweenClip && secondClip)
        {

            playingSoundSec.Play();
            secondClip = false;

        }

        while (!playingSoundSec.isPlaying && !secondClip && !betweenClip && implusePlay)
        {
            impulse();
            implusePlay = false;

        }
    }
    void impulse() {

        leftHand.SendHapticImpulse(0, 1f, 5.0f);
        rightHand.SendHapticImpulse(0, 1f, 5.0f);
    }
}
