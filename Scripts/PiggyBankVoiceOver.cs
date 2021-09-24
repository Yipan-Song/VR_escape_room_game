using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBankVoiceOver : MonoBehaviour
{
    private AudioSource playingSoundPiggyBank;
    private bool ifSoundOnePlaying;
    private bool ifSoundTwoPlaying;
    private float up;
    private float updateDiff;
    private Vector3 originalPosition;
    private bool checkMove = false;
    private bool piggyBankSound = true;
    private Vector3 piggyUpdatePosition;
    private AudioSource narrative1;
    private AudioSource narrative2;
    public bool IfpiggyBankVoiceWork = false;
    private bool IfkeySoundWork = false;
    // Start is called before the first frame update
    void Start()
    {

        playingSoundPiggyBank = GetComponent<AudioSource>();
        piggyUpdatePosition = transform.position;
        originalPosition = transform.position;

        Invoke("letCheckMove", 2.0f);
       


    }
    void letCheckMove()
    {
        checkMove = true;
    }

    private void FixedUpdate()
    {
        up = transform.position.y - originalPosition.y;
        updateDiff = transform.position.y - piggyUpdatePosition.y;
        if (GameObject.FindObjectOfType<KeyGeneration>() != null)
        {
            IfkeySoundWork = GameObject.FindObjectOfType<KeyGeneration>().firstKeySound;
        }
        if (Mathf.Abs(up) > 0.1 && piggyBankSound)
        {

                playingSoundPiggyBank.Play();
                piggyBankSound = false;
                IfpiggyBankVoiceWork = true;
        }
        if(IfkeySoundWork)
        {
            playingSoundPiggyBank.Stop();
        }
        piggyUpdatePosition = transform.position;
    }

}
