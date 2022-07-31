using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*** Following script allows for user to roll dice ***/

public class DiceThrow : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    public int offsetCamera = 500;
    [HideInInspector] public bool hasFallen = false;  //Checks if the object as fallen

    private bool isGrabbed = false;
    private Vector3 dicePos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        dicePos = Camera.main.WorldToScreenPoint(transform.position);
    }

    void Update()
    {
        Vector3 euler = transform.eulerAngles;

        diceVelocity = rb.velocity;
        
        //get dice to idle rotate center of screen if not selected
        if (!isGrabbed)
        {
            //Centers camera to screen
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, offsetCamera));

            //Rotates dice / issue with dice rotation too fast
            euler.x = Random.Range(0, 360f);
            //euler.y = Random.Range(0f, 360f);
            euler.z = Random.Range(0, 360f);
            transform.eulerAngles = euler;
        }

        //user can click on die to move it and shake it
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isGrabbed = true;   //Stops from rotating

            //Place move and shake script here
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        }

        //Once user lets go throw dice
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            rb.useGravity = true;
            hasFallen = true;
        }

        //dice stops moving and determines number 
        //Have determine Number another script
    }
}
