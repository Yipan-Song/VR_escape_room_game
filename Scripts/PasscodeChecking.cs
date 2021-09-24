using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PasscodeChecking : MonoBehaviour
{
    public Button btn_1;
    public Button btn_2;
    public Button btn_3;
    public Button btn_4;
    public Button btn_5;
    public Button btn_6;
    public Button btn_7;
    public Button btn_8;
    public Button btn_9;
    public Button btn_0;
    public GameObject promptTwelve;
    public GameObject key3;

    public GameObject hintOne;
    public GameObject hintTwo;
    public GameObject phoneTappingSound;

    public bool ifPassCodeSoundWork = true;
    private bool ifHintOneSoundWork = false;
    private bool ifHintTwoSoundWork = false;
    private GameObject key;
    private Vector3 keyPosition;
    private float upDiff;
    private GameObject afterReadMessage;
    private GameObject afterKeyShow_1;
    private GameObject afterKeyShow_2;
    private bool keySoundPlay = true;
    private bool ifKeyShow = false;
    private bool ifKeyVoice_1_Show = false;
    private bool end = false;
  
    private int[] correctPasscode = { 1, 2, 0, 6 };
    private int[] userInput = new int[4];
    private int i = 0;

    private int timesOfFalsePasscode = 0;

    private InputDevice leftHand;
    private InputDevice rightHand;
    private AudioSource PasscodeVoice;
    [System.Obsolete]
    private void Start()
    {
        PasscodeVoice = GetComponent<AudioSource>();
        promptTwelve.SetActive(true) ;
        // Start the listener
        btn_0.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(0); });
        btn_1.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(1); });
        btn_2.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(2); });
        btn_3.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(3); });
        btn_4.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(4); });
        btn_5.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(5); });
        btn_6.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(6); });
        btn_7.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(7); });
        btn_8.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(8); });
        btn_9.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(9); });

        afterReadMessage = transform.parent.Find("Message Panel").transform.GetChild(0).gameObject;
        key = transform.parent.Find("Message Panel").transform.GetChild(1).gameObject;
        afterKeyShow_1 = transform.parent.Find("Message Panel").transform.GetChild(2).gameObject;
        afterKeyShow_2 = transform.parent.Find("Message Panel").transform.GetChild(3).gameObject;

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


    private void Update()
    {
        if(ifHintOneSoundWork)
        { PasscodeVoice.Stop(); }
    }
    void TaskOnClick(int btn_number)
    {
        i++;
        transform.GetChild(i + 9).gameObject.SetActive(true);
        userInput[i - 1] = btn_number;
        Debug.Log("User input: " + btn_number);
        phoneTappingSound.GetComponent<AudioSource>().Play();

        if (i == 4)
        {
            transform.GetChild(i + 9).gameObject.SetActive(true);
            i = 0;

            bool isPassCorrect = true;

            Debug.Log(userInput);
            for (int m = 0; m < userInput.Length; m++)
            {
                Debug.Log(userInput[m] + "==" + correctPasscode[m]);
                if (userInput[m] != correctPasscode[m])
                {
                    isPassCorrect = false;
                }
            }

            if (isPassCorrect)
            {
                Debug.Log("You win!");
                promptTwelve.SetActive(false);
                transform.parent.Find("Passcode Panel").gameObject.SetActive(false);
                transform.parent.Find("Message Panel").gameObject.SetActive(true);
                afterReadMessage.SetActive(true);
                Invoke("keyShow", 2.0f);
            }
            else
            {
                userInput = new int[4];

                Debug.Log("The passcode is not correct.");
                timesOfFalsePasscode++;

                if (timesOfFalsePasscode == 1)
                {
                    hintOne.SetActive(true);
                    ifHintOneSoundWork = true;
                }

                if (timesOfFalsePasscode == 2)
                {
                    hintTwo.SetActive(true);
                    ifHintTwoSoundWork = true;
                }

                for (int m = 10; m < 14; m++)
                {
                    transform.GetChild(m).gameObject.SetActive(false);
                }
                impulse();
            }

        }
    }

    void keyShow()
    {
        key.SetActive(true);
        Invoke("key3_show", 0.1f);

    }

    void impulse()
    {
        leftHand.SendHapticImpulse(0, 1f, 0.5f);
        rightHand.SendHapticImpulse(0, 1f, 0.5f);
    }
}
