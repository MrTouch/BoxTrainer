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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Set back & front hand
        setHands();

        //Check if collision occured in this frame
        if (lastCollision != null)
        {
            //Switch on move, which should be done
            switch (currentMove)
            {
                case Move.jab:
                    if (collidingHand == frontHand)
                    {
                        Debug.Log("Nice one");
                    }
                    else
                    {
                        Debug.Log("Much to learn you still have my young padawan.");
                    }
                    break;

                case Move.punch:
                    if (collidingHand == backHand)
                    {
                        Debug.Log("Nice one");
                    }
                    else
                    {
                        Debug.Log("Much to learn you still have my young padawan.");
                    }
                    break;

                case Move.uppercutLeft:
                    if (collidingHand == leftHand)
                    {
                        Debug.Log("Nice one");
                    }
                    else
                    {
                        Debug.Log("Much to learn you still have my young padawan.");
                    }
                    break;

                case Move.uppercutRight:
                    if (collidingHand == rightHand)
                    {
                        Debug.Log("Nice one");
                    }
                    else
                    {
                        Debug.Log("Much to learn you still have my young padawan.");
                    }
                    break;

                case Move.hookLeft:
                    if (collidingHand == leftHand)
                    {
                        Debug.Log("Nice one");
                    }
                    else
                    {
                        Debug.Log("Much to learn you still have my young padawan.");
                    }
                    break;

                case Move.hookRight:
                    if (collidingHand == rightHand)
                    {
                        Debug.Log("Nice one");
                    }
                    else
                    {
                        Debug.Log("Much to learn you still have my young padawan.");
                    }
                    break;

                case Move.block:
                    //Do stuff
                    break;

                case Move.evade:
                    //Do stuff
                    break;

                default:
                    Debug.Log("Unknown move");
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
    enum Move {jab,punch,uppercutLeft,uppercutRight,hookLeft,hookRight,block,evade}
}
