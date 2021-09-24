using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingToPasscode : MonoBehaviour
{
    public GameObject promptEleven;
    public GameObject promptTwelve;
    public bool promptElevenShow = true;
    public void switchingToPasscode()
    {
        promptEleven.SetActive(false);
        promptTwelve.SetActive(true);
        promptElevenShow = false;
        transform.parent.Find("Panel").gameObject.SetActive(false);
        transform.parent.Find("Passcode Panel").gameObject.SetActive(true);

    }
}
