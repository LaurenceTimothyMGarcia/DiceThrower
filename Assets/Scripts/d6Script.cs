using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d6Script : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    private Transform[] listOfChecks;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rb.velocity;

        //get dice to idle rotate center of screen if not selected

        //user can click on die to move it and shake it
            //Once user lets go throw dice

        //dice stops moving and determines number
    }
}
