using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*** Following script checks for dice result ***/

public class D6Check : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] DiceThrow diceThrow;

    public Vector3 diceVelocity;

    public Transform[] diceSides;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        //Checks if dice stopped rolling
        if (diceVelocity.magnitude <= 0.001 && diceThrow.hasFallen)//needs to check also if there is no more rotation look into quaternions
        {
            Debug.Log("Stopped lmao");

        }
    }
}
