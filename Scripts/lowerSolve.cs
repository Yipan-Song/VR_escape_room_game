using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class lowerSolve : MonoBehaviour
{
    // Setting the correct object (puzzle solution)
    public GameObject firstBook;
    public GameObject secondBook;
    public GameObject thirdBook;
    public GameObject fourthBook;
    public GameObject fifthBook;
    public bool lowerSolved = false;

    // For storing books' position
    Vector3 point1;
    Vector3 point2;
    Vector3 point3;
    Vector3 point4;
    Vector3 point5;
    Vector3 point6;

    AudioSource bookDrop;

    public Collider selectedLayer;

    // check if the book is in its corresponding layer
    private bool firstbookinLayer = false;
    private bool secbookinLayer = false;
    private bool thirbookinLayer = false;
    private bool fourbookinLayer = false;
    private bool fifbookinLayer = false;
    private bool booktouching = false;
    public int bookAmountCurrentLayer = 0;
    public int bookAmountprevious = 0;

    public bool isGrabbed = false;
    int numberMatched = 0;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        bookDrop = GetComponent<AudioSource>();
        if (other.name != "bookcase")
        {
            bookAmountCurrentLayer++;
        }


    }

    void OnTriggerExit(Collider other)
    {
        bookAmountCurrentLayer--;
        bookAmountprevious = bookAmountCurrentLayer;
        booktouching = true;
        Debug.Log("exitTrigger" + bookAmountCurrentLayer);
    }

    private void Update()
    {
        point1 = firstBook.transform.position;
        point2 = secondBook.transform.position;
        point3 = thirdBook.transform.position;
        point4 = fourthBook.transform.position;
        point5 = fifthBook.transform.position;

        float[] layerOrder_Yaix = new float[] { point1.y, point2.y, point3.y, point4.y, point5.y };
        if (bookAmountprevious < bookAmountCurrentLayer && booktouching)
        {

            foreach (float Y_aix in layerOrder_Yaix)
            {
                if ((gameObject.name == "topLayer" && Y_aix < 2.73 && Y_aix > 2.7) || (gameObject.name == "middleLayer" && Y_aix < 2.4 && Y_aix > 2) || (gameObject.name == "lowerLayer" && Y_aix < 1.93 && Y_aix > 1.9))
                {
                    bookDrop.Play();
                    booktouching = false;
                    bookAmountprevious = bookAmountCurrentLayer;
                    //Debug.Log("gameobject : " + gameObject.name);
                }
            }

        }
        if (selectedLayer.bounds.Contains(point1))
        {
            firstbookinLayer = true;
        }
        else
        {
            firstbookinLayer = false;
        }

        if (selectedLayer.bounds.Contains(point2))
        {
            secbookinLayer = true;
        }
        else
        {
            secbookinLayer = false;
        }

        if (selectedLayer.bounds.Contains(point3))
        {
            thirbookinLayer = true;
        }
        else
        {
            thirbookinLayer = false;
        }

        if (selectedLayer.bounds.Contains(point4))
        {
            fourbookinLayer = true;
        }
        else
        {
            fourbookinLayer = false;
        }
        if (selectedLayer.bounds.Contains(point5))
        {
            fifbookinLayer = true;
        }
        else
        {
            fifbookinLayer = false;
        }

        if (firstbookinLayer && fifbookinLayer && fourbookinLayer && thirbookinLayer && secbookinLayer && bookAmountCurrentLayer == 5)
        {
            float[] layerOrder = new float[] { point1.z, point2.z, point3.z, point4.z, point5.z };

            float[] playerInput = new float[] { point1.z, point2.z, point3.z, point4.z, point5.z };
            Array.Sort(playerInput);
            for (var i = 0; i < 5; i++)
            {
                if (playerInput[i] == layerOrder[i])
                {
                    numberMatched++;
                }
            }

            if (numberMatched == 5)
            {
                lowerSolved = true;


            }
            else
            {
                Debug.Log("Wrong answer! Retry!");
                lowerSolved = false;
            }
            numberMatched = 0;
        }

        else if (bookAmountCurrentLayer > 5)
        {
            lowerSolved = false;
        }
        else {
            lowerSolved = false;
        }
    }
}
