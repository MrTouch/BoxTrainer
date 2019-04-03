using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensei_script : MonoBehaviour
{
    [SerializeField] private Move currentMove = Move.jab;

    [HideInInspector] public Collision lastCollision;
    [HideInInspector] public GameObject collidingHand;

    //Hands; front & back dynamically set. Left & right set via editor
    private GameObject frontHand;
    private GameObject backHand;

    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    [SerializeField] audio_controller audioController;


    // Start is called before the first frame update
    void Start()
    {
        chooseMove();
    }

    // Update is called once per frame
    void Update()
    {
        //Set back & front hand
        if(Input.GetKeyDown("1")) setHands();

        //Debug
        if (Input.GetKeyDown("2")) audioController.playPunch();

        if (Input.GetKeyDown("3"))
        {
            chooseMove();
            Debug.Log(currentMove);
        }

        //// Move check logic ////
        //Check if collision occured in this frame
        if (lastCollision != null)
        {
            audioController.playPunch();

            //Switch on move, which should be done
            switch (currentMove)
            {
                case Move.jab:
                    if (collidingHand == frontHand)
                    {
                        audioController.playGood();
                        chooseMove();
                     }
                    else
                    {
                        audioController.playBad();                    
                    }
                    break;

                case Move.punch:
                    if (collidingHand == backHand)
                    {
                        audioController.playGood();
                        chooseMove();
                    }
                    else
                    {
                        audioController.playBad();                    
                    }
                    break;

                case Move.uppercutLeft:
                    if (collidingHand == leftHand)
                    {
                        audioController.playGood();
                        chooseMove();
                    }
                    else
                    {
                        audioController.playBad();
                    }
                    break;

                case Move.uppercutRight:
                    if (collidingHand == rightHand)
                    {
                        audioController.playGood();
                        chooseMove();
                    }
                    else
                    {
                        audioController.playBad();
                    }
                    break;

                case Move.hookLeft:
                    if (collidingHand == leftHand)
                    {
                        audioController.playGood();
                        chooseMove();
                    }
                    else
                    {
                        audioController.playBad();
                    }
                    break;

                case Move.hookRight:
                    if (collidingHand == rightHand)
                    {
                        audioController.playGood();
                        chooseMove();
                    }
                    else
                    {
                        audioController.playBad();
                    }
                    break;

                default:
                    Debug.Log("Seinsei:: Unknown move");
                    break;
            }
        }
        //Reset collision at the end of each frame
        lastCollision = null;
    }

    //Function to set front and back hand
    void setHands()
    {
        Vector3 leftHandPos = leftHand.transform.position;
        Vector3 rightHandPos = rightHand.transform.position;

        if (leftHandPos.z < rightHandPos.z)
        {
            frontHand = leftHand;
            backHand = rightHand;
        }
        else
        {
            frontHand = rightHand;
            backHand = leftHand;
        }
    }

    void chooseMove() 
    { 
        currentMove =  (Move)Random.Range(0, System.Enum.GetValues(typeof(Move)).Length);
        audioController.playMove(currentMove);
    }

    public enum Move {jab,punch,uppercutLeft,uppercutRight,hookLeft,hookRight}
}
