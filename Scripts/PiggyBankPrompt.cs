using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBankPrompt : MonoBehaviour
{
    public GameObject promptFour;
    public GameObject promptFive;

    private bool prompted = false;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("infrontof desk :: " + other.tag);
        if (other.tag == "Player" && !prompted)
        {
            promptFour.SetActive(false);
            promptFive.SetActive(true);
            prompted = true;
            Debug.Log("prompt 4 close");
            Invoke("TurnOffPromptFive", 3.0f);
        }
    }

    void TurnOffPromptFive() 
    {
        promptFive.SetActive(false);
        Destroy(gameObject);
    }
}
