using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck : MonoBehaviour
{
    public GameObject key;
    public GameObject bookcaseCollider;
    private topSolve topsolve;
    private middleSolve middlesolve;
    private lowerSolve lowersolve;
    private AudioSource booksPuzzleSolved;
    private bool topSolved = false;
    private bool middleSolved = false;
    private bool lowerSolved = false;



    // Start is called before the first frame update
    void Start()
    {
        booksPuzzleSolved = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        topsolve = GameObject.FindObjectOfType<topSolve>();
        middlesolve = GameObject.FindObjectOfType<middleSolve>();
        lowersolve = GameObject.FindObjectOfType<lowerSolve>();
        topSolved = topsolve.topSolved;
        middleSolved = middlesolve.middleSolved;
        lowerSolved = lowersolve.lowerSolved;

        if (topSolved)
        {
            if (middleSolved) {
                if (lowerSolved)
                {

                    bookcaseCollider.SetActive(false);

                    Debug.Log("Bookshelf puzzle is solved!");

                    key.SetActive(true);

                }
                        
            }
        }
    }
}
