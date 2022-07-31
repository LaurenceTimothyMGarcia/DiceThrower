using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*** Following script checks for dice result ***/

public class D6Check : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private DiceThrow diceThrow;
    [SerializeField] private Transform[] diceSides;

    [HideInInspector] public Vector3 diceVelocity;

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
        if (diceVelocity.magnitude <= 0.001 && diceThrow.hasFallen)
        {
            //Debug.Log("Stopped lmao");
            CheckTopSide(diceSides);
        }
    }

    //Looks for what side of die is on top
    private void CheckTopSide(Transform[] diceSides)
    {
        float highestSide = diceSides[0].position.y;
        int topSide = 1;

        //Initializing Dice Sides
        for (int i = 0; i < diceSides.Length; i++)
        {
            if (highestSide < diceSides[i].position.y)
            {
                highestSide = diceSides[i].position.y;
                topSide = i + 1;
            }
        }

        //Print result here
        Debug.Log("Rolled: " + topSide);
    }
}
