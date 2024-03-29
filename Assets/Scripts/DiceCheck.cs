using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*** Following script checks for dice result ***/

public class DiceCheck : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private DiceThrow diceThrow;
    [SerializeField] private bool isD10;
    [SerializeField] private bool isD100;
    [SerializeField] private Transform[] diceSides;
    [SerializeField] TMP_Text diceResult;
    private Canvas canvasUI;

    [HideInInspector] public Vector3 diceVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Can get rid of this later
        canvasUI = FindObjectOfType<Canvas>();
        diceResult = canvasUI.GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        //Checks if dice stopped rolling
        if (diceVelocity.magnitude <= 0.00001 && diceThrow.hasFallen)
        {
            CheckTopSide(diceSides);
        }
    }

    //Looks for what side of die is on top
    private void CheckTopSide(Transform[] diceSides)
    {
        float highestSide = diceSides[0].position.y;    //looks for which one is the highest
        int topSide = 1;    //actual side of dice

        //Initializing Dice Sides
        for (int i = 0; i < diceSides.Length; i++)
        {
            if (highestSide < diceSides[i].position.y)
            {
                highestSide = diceSides[i].position.y;
                topSide = i + 1;
            }
        }

        //Makes D10 Score multiple of 10
        if (isD100)
        {
            topSide -= 1;
            topSide *= 10;
        }

        //Print result here
        diceResult.text = "Rolled: " + topSide;
    }
}
