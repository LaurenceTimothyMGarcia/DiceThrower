using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d6Script : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    private Transform[] listOfChecks;
    private bool isGrabbed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        Vector3 euler = transform.eulerAngles;

        diceVelocity = rb.velocity;
        

        //get dice to idle rotate center of screen if not selected
        if (!isGrabbed)
        {
            euler.x = Random.Range(0, 360f);
            //euler.y = Random.Range(0f, 360f);
            euler.z = Random.Range(0, 360f);
            transform.eulerAngles = euler;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            isGrabbed = true;
        }

        //user can click on die to move it and shake it
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Place move and shake script here
        }

        //Once user lets go throw dice
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            rb.useGravity = true;
        }

        //dice stops moving and determines number 
        //Have determine Number another script
    }
}
