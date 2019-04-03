using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensei_script : MonoBehaviour
{
    private Move currentMove = Move.jab;

    [HideInInspector] public Collision lastCollision;
    [HideInInspector] public GameObject collidingHand;

    //Hands; front & back dynamically set. Left & right set via editor
    private GameObject frontHand;
    private GameObject backHand;

    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    [SerializeField] audio_controller audioController;

    [SerializeField] Animator animator;

    private int upperCutRightHash = Animator.StringToHash("upperCutRight");
    private int upperCutLeftHash = Animator.StringToHash("upperCutLeft");
    private int hookRightHash = Animator.StringToHash("hookRight");
    private int hookLeftHash = Animator.StringToHash("hookLeft");
    private int jabHash = Animator.StringToHash("jab");
    private int punchHash = Animator.StringToHash("punch");

    private int chooseDelay = 1;

    private bool processedFlag = false;


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
        
        if (Input.GetKeyDown("2"))
        {
            audioController.playGood();
            animator.enabled = true;
            StartCoroutine(chooseMoveCoroutine(chooseDelay));
        }


        //// Move check logic ////
        //Check if collision occured in this frame
        if (lastCollision != null && !processedFlag)
        {
            audioController.playPunch();

            //Switch on move, which should be done
            switch (currentMove)
            {
                case Move.jab:
                    if (collidingHand == frontHand)
                    {
                        audioController.playGood();
                        animator.enabled = true;
                        processedFlag = true;
                        StartCoroutine(chooseMoveCoroutine(chooseDelay));
                     }
                    else
                    {
                        audioController.playBad();
                        lastCollision = null;
                        processedFlag = false;
                    }
                    break;

                case Move.punch:
                    if (collidingHand == backHand)
                    {
                        audioController.playGood();
                        animator.enabled = true;
                        processedFlag = true;
                        StartCoroutine(chooseMoveCoroutine(chooseDelay));
                    }
                    else
                    {
                        audioController.playBad();
                        lastCollision = null;
                        processedFlag = false;
                    }
                    break;

                case Move.uppercutLeft:
                    if (collidingHand == leftHand)
                    {
                        audioController.playGood();
                        animator.enabled = true;
                        processedFlag = true;
                        StartCoroutine(chooseMoveCoroutine(chooseDelay));
                    }
                    else
                    {
                        audioController.playBad();
                        lastCollision = null;
                        processedFlag = false;
                    }
                    break;

                case Move.uppercutRight:
                    if (collidingHand == rightHand)
                    {
                        audioController.playGood();
                        animator.enabled = true;
                        processedFlag = true;
                        StartCoroutine(chooseMoveCoroutine(chooseDelay));
                    }
                    else
                    {
                        audioController.playBad();
                        lastCollision = null;
                        processedFlag = false;
                    }
                    break;

                case Move.hookLeft:
                    if (collidingHand == leftHand)
                    {
                        audioController.playGood();
                        animator.enabled = true;
                        processedFlag = true;
                        StartCoroutine(chooseMoveCoroutine(chooseDelay));
                    }
                    else
                    {
                        audioController.playBad();
                        lastCollision = null;
                        processedFlag = false;
                    }
                    break;

                case Move.hookRight:
                    if (collidingHand == rightHand)
                    {
                        audioController.playGood();
                        animator.enabled = true;
                        processedFlag = true;
                        StartCoroutine(chooseMoveCoroutine(chooseDelay));
                    }
                    else
                    {
                        audioController.playBad();
                        lastCollision = null;
                        processedFlag = false;
                    }
                    break;

                default:
                    Debug.Log("Seinsei:: Unknown move");
                    break;
            }
        }
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
        Debug.Log("FH: " + frontHand.gameObject.name + " BH: " + backHand.gameObject.name);
    }

    public void chooseMove() 
    { 
        currentMove =  (Move)Random.Range(0, System.Enum.GetValues(typeof(Move)).Length);
        audioController.playMove(currentMove);

        switch (currentMove)
        {
            case Move.hookLeft:
                animator.SetTrigger(hookLeftHash);
                break;

            case Move.hookRight:
                animator.SetTrigger(hookRightHash);
                break;

            case Move.jab:
                animator.SetTrigger(jabHash);
                break;

            case Move.punch:
                animator.SetTrigger(punchHash);
                break;

            case Move.uppercutLeft:
                animator.SetTrigger(upperCutLeftHash);
                break;

            case Move.uppercutRight:
                animator.SetTrigger(upperCutRightHash);
                break;

            default:
                Debug.Log("Sensei: Unknown move for animation");
                break;
        }
        lastCollision = null;
        processedFlag = false;
    }

    public enum Move {jab,punch,uppercutLeft,uppercutRight,hookLeft,hookRight}

    IEnumerator chooseMoveCoroutine(int delay)
    {
        yield return new WaitForSeconds(delay);
        chooseMove();
    }
}
