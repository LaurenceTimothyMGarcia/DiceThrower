using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*** Following script allows for user to roll dice ***/

public class DiceThrow : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    [Header("Text")]
    [SerializeField] TMP_Text diceText;

    [Header("Speed of Dice Rotation")]
    [SerializeField] private float idleX;
    [SerializeField] private float idleY;
    [SerializeField] private float idleZ;

    [Header("Dice from camera")]
    [SerializeField] int offsetCamera = 10;

    [Header("Delay in dice following mouse")]
    [SerializeField] float followSpeed = 5;

    [Header("Throwing dice Variables")]
    [SerializeField] float throwMaxSpeed = 20;
    [SerializeField] float flickSpeed = 3;
    [SerializeField] float curveStrength = 1;

    [HideInInspector] public bool hasFallen = false;  //Checks if the object as fallen
    [HideInInspector] public Vector3 dicePos;

    private bool isGrabbed = false;
    private Vector3 mousePos;
    private Vector3 euler;
    private Quaternion diceRot;

    private Vector3 mouseDir
    {
        get
        {
            return Input.mousePosition - mousePos;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        dicePos = Camera.main.WorldToScreenPoint(transform.position);

        //Set a random dice rotation before the player rolls
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 1);
    }

    void Update()
    {
        diceVelocity = rb.velocity;
        mousePos = Input.mousePosition;
        
        //get dice to idle rotate center of screen if not selected
        if (!isGrabbed)
        {
            //Centers camera to screen
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, offsetCamera));
        }
    }

    void FixedUpdate()
    {
        if (!isGrabbed)
        {
            //Rotates dice when idle
            transform.Rotate(idleX * Time.deltaTime, idleY * Time.deltaTime, idleZ * Time.deltaTime);
        }
    }

    //user can click on die to move it and shake it
    void OnMouseDown()
    {
        rb.useGravity = false;  //Removes gravity
        isGrabbed = true;   //Stops from rotating
        hasFallen = false;

        //Setting text
        diceText.text = "Rolling Dice...";
    }

    void OnMouseDrag()
    {
        //Dice follows mouse, gives delay in follow speed
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, offsetCamera)), followSpeed/100);

        //add rotation while moving dice here
        transform.Rotate(mouseDir.y, mouseDir.x, 0, Space.World);   //bounds dice to rotate a specific way
    }

    //Once user lets go throw dice
    void OnMouseUp()
    {
        rb.useGravity = true;
        rb.velocity = new Vector3(0.001f, 0.001f, 0.001f);  //Temp fix to the issue of it rolling immediatley
        hasFallen = true;

        //Throw force, controlled by flick speed and can turn depending on curve strength
        rb.AddForce(new Vector3 (mouseDir.x * curveStrength, 0, mouseDir.y * flickSpeed), ForceMode.Impulse);

        //Try to keep rotation after flicking dice
        
    }

    
}
