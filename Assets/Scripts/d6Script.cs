using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d6Script : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rb.velocity;

        if (Input.GetKeyDown (KeyCode.Space))
        {
            DiceNumberTextScript.diceNumber = 0;
            float dirX = Random.Range(0, 500);
        }
    }
}
