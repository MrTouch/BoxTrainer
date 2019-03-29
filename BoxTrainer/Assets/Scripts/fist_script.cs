using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fist_script : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private sensei_script sensei;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey("1"))
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("2"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);
        }*/
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "collider")
        {
            sensei.lastCollision = col;
            sensei.collidingHand = this.gameObject;
        }
    }


}
