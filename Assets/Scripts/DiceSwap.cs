using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*** Following Program allows user to switch which dice they want ***/

public class DiceSwap : MonoBehaviour
{
    [Header("Dice Prefabs")]
    [SerializeField] private GameObject D4;
    [SerializeField] private GameObject D6;
    [SerializeField] private GameObject D8;
    [SerializeField] private GameObject D10;
    [SerializeField] private GameObject D100;
    [SerializeField] private GameObject D12;
    [SerializeField] private GameObject D20;

    [Header("Button Elements")]
    [SerializeField] private Canvas canvasElement;

    private GameObject[] activeDice;
    private DiceThrow dThrow;

    //private bool[] activeDiceTrue = new bool[] {false, false, false, false, false, false, false};
    private bool activeD4;
    private bool activeD6;
    private bool activeD8;
    private bool activeD10;
    private bool activeD100;
    private bool activeD12;
    private bool activeD20;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void D4Button()
    {
        Debug.Log("D4 Button");
        //SetDiceBool(0);
        Instantiate(D4);
    }

    public void D6Button()
    {
        Debug.Log("D6 Button");
        //SetDiceBool(1);
        Instantiate(D6);
    }

    public void D8Button()
    {
        Debug.Log("D8 Button");
        //SetDiceBool(2);
        Instantiate(D8);
    }

    public void D10Button()
    {
        Debug.Log("D10 Button");
        //SetDiceBool(3);
        Instantiate(D10);
    }

    public void D100Button()
    {
        Debug.Log("D100 Button");
        //SetDiceBool(4);
        Instantiate(D100);
    }

    public void D12Button()
    {
        Debug.Log("D12 Button");
        //SetDiceBool(5);
        Instantiate(D12);
    }

    public void D20Button()
    {
        Debug.Log("D20 Button");
        //SetDiceBool(6);
        Instantiate(D20);
    }

    /*private void SetDiceBool(int dice)
    {
        for (int i = 0; i < activeDiceTrue.Length; i++)
        {
            if (i == dice)
            {
                activeDiceTrue[i] = true;
            }
            else
            {
                activeDiceTrue[i] = false;
            }
        }
    }*/
}
