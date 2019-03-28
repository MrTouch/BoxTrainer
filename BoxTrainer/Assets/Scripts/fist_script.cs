using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fist_script : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private GameObject leftHand;

    [SerializeField]
    private GameObject rightHand;

    [SerializeField]
    private sensei_script sensei;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setHands();

        if (Input.GetKey("1"))
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("2"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "collider")
        {
            sensei.lastCollision = col;
            sensei.collidingHand = this.gameObject;
        }
    }

    void setHands() 
    {
        Vector3 leftHandPos = leftHand.transform.position;
        Vector3 rightHandPos = rightHand.transform.position;

        if (leftHandPos.z < rightHandPos.z)
        {
            sensei.frontHand = leftHand;
            sensei.backHand = rightHand;
        }
        else
        {
            sensei.frontHand = rightHand;
            sensei.backHand = leftHand;
        }
    }
}
