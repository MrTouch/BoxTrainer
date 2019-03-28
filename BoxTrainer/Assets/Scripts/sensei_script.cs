using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensei_script : MonoBehaviour
{
    [SerializeField]
    private Move currentMove = Move.jab;

    public Collision lastCollision;
    public GameObject collidingHand;

    public GameObject frontHand;
    public GameObject backHand;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentMove)
        {
            case Move.jab:
                if (lastCollision != null)
                {
                    if (collidingHand == frontHand)
                    {
                        Debug.Log("Nice one");
                    }
                    else
                    {
                        Debug.Log("Much to learn you still have my young padawan.");
                    }
                }
                break;
            
            case Move.punch:
                if (lastCollision != null)
                {
                    if (collidingHand == backHand)
                    {
                        Debug.Log("Nice one");
                    }
                    else
                    {
                        Debug.Log("Much to learn you still have my young padawan.");
                    }
                }
                break;
            
            case Move.uppercutLeft:
                //Do stuff
                break;

            case Move.uppercutRight:
                //Do stuff
                break;

            case Move.hookLeft:
                //Do stuff
                break;

            case Move.hookRight:
                //Do stuff
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
        lastCollision = null;
    }



    enum Move {jab,punch,uppercutLeft,uppercutRight,hookLeft,hookRight,block,evade}
}
