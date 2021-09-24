using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneThree : MonoBehaviour
{
    public GameObject bookshelfAnchor;
    public GameObject deskAnchor;

    public GameObject promptNine;

    private DisplayKeys displaykeys;

    public GameObject iPhone;
    public bool phoneFirstVoice = false;
    private GameObject S3L1Obj;
    private GameObject S2L6Obj;

    // Start is called before the first frame update
    void Start()
    {

        S3L1Obj = transform.GetChild(0).gameObject; 
        S2L6Obj = transform.GetChild(1).gameObject;
        Invoke("S2L6", 1.0f);
        Invoke("activatePhone", 13.0f);
        Invoke("S3L1", 14.0f);
        displaykeys = GameObject.FindObjectOfType<DisplayKeys>();

    }

    void S2L6()
    {
        S2L6Obj.SetActive(true);
        promptNine.SetActive(true);
        bookshelfAnchor.SetActive(false);
        deskAnchor.SetActive(true);
    }
    void activatePhone()
    {
        iPhone.SetActive(true);
        phoneFirstVoice = true;
    }
    void S3L1()
    {
        S3L1Obj.SetActive(true);
    }
}
