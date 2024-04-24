using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    // dice setting
    private DiceController[] diceControllerObject;
    // dice config for speed, torque, ...
    private DiceData diceData;
    // referennce of dice prefabs
    public GameObject diceObject;

    // basic func
    public Transform summonPos;
    public Rigidbody diceRigibody;
    public int valueDice;

    // chessbox controller
    private ChessBoxController chessBoxController;

    // player controller
    public int size;
    private PlayerController playerController;
    private int turn;
    private bool isEndTurn;

    void InitDice()
    {
        diceControllerObject = new DiceController[2];

        for (int i = 0; i < 2; i++)
        {
            diceControllerObject[i] = new DiceController();
        }
        diceData = new DiceData(summonPos, diceRigibody, diceObject, false, false);
        isEndTurn = false;
    }

    void InitPlayer()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerController.InitPlayer(size);

    }
    
    void Start()
    {
        InitDice();
        InitPlayer();
        turn = 0;


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (diceControllerObject[0].CheckQuantity())
            {
                diceData.isFinishDice = false;
                diceData.isInitDice = true;
                diceControllerObject[0].Init(diceData);
                diceControllerObject[1].Init(diceData);
                diceControllerObject[0].Process();
                diceControllerObject[1].Process();
            }
        }
        if (diceData.isInitDice)
        {
            if (diceControllerObject[0].CheckStop() && diceControllerObject[1].CheckStop())
            {
                diceData.isFinishDice = true;
                valueDice = diceControllerObject[0].GetValueRoll() + diceControllerObject[1].GetValueRoll();

            }
        }

        if (diceData.isFinishDice)
        {
            playerController.Move(valueDice, turn);
            diceData.isFinishDice = false;
            diceData.isInitDice = false;
        }

        if (isEndTurn)
        {
            turn++;
            turn %= 2;
            diceControllerObject[0].Destroy();
            diceControllerObject[1].Destroy();
            isEndTurn = false;
        }
    }

    public void OnEndButton()
    {
        isEndTurn = true;
    }

    public void OnBuyButtonn()
    {
        playerController.Buy(turn);
    }
}
