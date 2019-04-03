using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fist_script : MonoBehaviour
{
    [SerializeField]
    private sensei_script sensei;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Handschuh")
        {
            sensei.lastCollision = col;
            sensei.collidingHand = this.gameObject;

        }
    }


}
