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

    private DiceThrow dThrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
