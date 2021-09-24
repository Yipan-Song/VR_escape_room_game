using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCollider : MonoBehaviour
{
    public GameObject promptTen;
    public GameObject promptEleven;
    public GameObject promptTwelve;

    private bool S3L2 = true;
    private bool IfPasscodeSoundWork = false;
    private AudioSource S3L2Audio;
    private bool phoneColliderVoice = false;
    private bool phoneColliderVoicePlay = true;
    private GameObject S3L3Obj;
    private DisplayKeys displaykeys;
    private bool ifSecondKeyInLock;
    private bool letPromptTenShow = true;
    private SpotLightControl spotlightControl;
    private bool letDoorAnchorShow;
    private bool letpromptElevenShow = true;
    public GameObject doorAnchor;

    // Start is called before the first frame update
    void Start()
    {
        S3L2Audio = GetComponent<AudioSource>();
        S3L3Obj = transform.GetChild(0).gameObject;
        displaykeys = GameObject.FindObjectOfType<DisplayKeys>();
        spotlightControl = GameObject.FindObjectOfType<SpotLightControl>();
    }
    private void Update()
    {
        if(GameObject.FindObjectOfType<PasscodeChecking>() != null)
        {
            IfPasscodeSoundWork = GameObject.FindObjectOfType<PasscodeChecking>().ifPassCodeSoundWork;
        }
        if(IfPasscodeSoundWork)
        {
            S3L2Audio.Stop();

        }    
        if(GameObject.FindObjectOfType<SwitchingToPasscode>() != null)
        {
            letpromptElevenShow = GameObject.FindObjectOfType<SwitchingToPasscode>().promptElevenShow;

        }
        letDoorAnchorShow = spotlightControl.ifletDoorAnchorShow;
        ifSecondKeyInLock = displaykeys.checkSecondKeyinLock;
        if(GameObject.FindObjectOfType<SceneThree>() != null)
        {
            phoneColliderVoice = GameObject.FindObjectOfType<SceneThree>().phoneFirstVoice;
        }

        if(phoneColliderVoice && ifSecondKeyInLock && letPromptTenShow)
        {
            promptTen.SetActive(true);
            Debug.Log("letDoorAnchorShow ::" + letDoorAnchorShow);
            if (!letDoorAnchorShow)
            {
                doorAnchor.SetActive(false);
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger :: " + other.tag);

        if (other.tag == "Player" && S3L2 && phoneColliderVoice && phoneColliderVoicePlay)
        {
            S3L2Audio.Play();
            letPromptTenShow = false;
            promptTen.SetActive(false);
            if (letpromptElevenShow)
            {
                promptEleven.SetActive(true);
            }
            Invoke("S3L3", 3.0f);
            phoneColliderVoice = false;
            phoneColliderVoicePlay = false;

        }
    }

    void S3L3() 
    {
        S3L3Obj.SetActive(true);
    }

}
