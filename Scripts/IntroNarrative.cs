using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class IntroNarrative : MonoBehaviour
{
    private AudioSource playingSound;

    private bool clipPlay = false;
    private int currentVoiceIndex = 0;
    private DoorSound doorSound;
    private bool ifDoorSoundWork = false;


    // Start is called before the first frame update
    void Start()
    {
        doorSound = GameObject.FindObjectOfType<DoorSound>();
        Invoke("firstClipplay", 2.0f);
        Debug.Log(transform.GetChild(0).gameObject.name);
        playingSound = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        ifDoorSoundWork = doorSound.doorSoundWork;
        while (!playingSound.isPlaying && clipPlay)
        {
            clipPlay = false;
            currentVoiceIndex++;

            switch (currentVoiceIndex)
            {
                case 1:
                    playingSound = transform.GetChild(currentVoiceIndex).gameObject.GetComponent<AudioSource>();
                    Invoke("firstClipplay", 3.0f);
                    break;

            }
        }

    }

    void firstClipplay()
    {
        playingSound.Play();
        if (ifDoorSoundWork)
        {
            playingSound.Stop();
        }
        clipPlay = true;
    }

}
