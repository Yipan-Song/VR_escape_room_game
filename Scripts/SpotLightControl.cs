using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightControl : MonoBehaviour
{
    public GameObject mainLightControl;

    public GameObject promptOne;
    public GameObject promptTwo;
    public GameObject promptThree;

    public GameObject bedAnchor;
    public GameObject doorAnchor;
    public GameObject promptThirteen;
    public GameObject doorTeleportAnchor;

    public bool ifletDoorAnchorShow = false;

    private Light myLight;
    private float expectedBrightness = 1.5f;
    private float intensity = 0;
    private bool lightWork = false;
    private BearLightening bearLightening;
    private bool ifBearMove = false;
    private bool spotLightTurnedOff = false;
    private bool ifturnonMainLight = true;
    private AudioSource switchSound;
    private bool ifSoundplay = true;
    private bool bearPickingHint = true;
    private DoorSound doorsound;
    private bool promptThreeShow;
    private bool ifletpromptThreeShow;
    private DisplayKeys displayKeys;

    // Start is called before the first frame update
    private void Start()
    {
        myLight = GetComponent<Light>();
        switchSound = GetComponent<AudioSource>();
        myLight.intensity = intensity;
        Invoke("Light", 4.0f);
        promptOne.SetActive(true);
        Invoke("SecondPrompt", 8.0f);
        bedAnchor.SetActive(true);
        doorsound = GameObject.FindObjectOfType<DoorSound>();
        displayKeys = GameObject.FindObjectOfType<DisplayKeys>();
    }
    void Light()
    {
        lightWork = true;
    }
    private void FixedUpdate()
    {
        ifletpromptThreeShow = displayKeys.letpromptThreeShow;
        promptThreeShow = doorsound.promptThreeIfShow;
        bearLightening = GameObject.FindObjectOfType<BearLightening>();
        if (GameObject.FindObjectOfType<Key3>() != null)
        {
            ifturnonMainLight = GameObject.FindObjectOfType<Key3>().mainLight;
            Debug.Log("ifturnonMainLight :: " + ifturnonMainLight);
        }
        ifBearMove = bearLightening.bearMove;
        if (intensity < expectedBrightness && lightWork && !ifBearMove)
        {
            myLight.intensity = intensity;
            intensity = (float)(intensity + 0.001);
        }

        if (ifBearMove && intensity > 0)
        {
            promptOne.SetActive(false);
            intensity = (float)(intensity - 0.01);
         myLight.intensity = intensity;
         bearPickingHint = false;
        }

        if (ifBearMove && myLight.intensity == 0 && ifturnonMainLight)
        {
            mainLightControl.SetActive(true);
        }

        if (!ifturnonMainLight)
        {
            mainLightControl.SetActive(false);
            if (ifSoundplay)
            {
                switchSound.Play();
                ifSoundplay = false;
                Debug.Log("Switch Sound Play");
            }
            ifletDoorAnchorShow = true;
            doorTeleportAnchor.SetActive(true);
            if (ifletpromptThreeShow)
            {
                promptThirteen.SetActive(true);
            }
            if(! ifletpromptThreeShow)
            {
                Destroy(promptThirteen);
            }
            Debug.Log("turn off main");
            Debug.Log("switch sound" + ifSoundplay);
        }

        if (!bearPickingHint && promptThreeShow)
        {
            promptTwo.SetActive(false);
            promptThree.SetActive(true);
            doorAnchor.SetActive(true);
        }

        if (!promptThreeShow) 
        {

            promptThree.SetActive(false);

        }
    }

    private void SecondPrompt()
    {
        promptOne.SetActive(false);
        promptTwo.SetActive(true);
    }
}
