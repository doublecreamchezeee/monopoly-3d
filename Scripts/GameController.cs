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
    private DiceController[] diceControllerObject;
    private DiceData diceData;


    public GameObject diceObject;
    public Transform summonPos;
    public Rigidbody diceRigibody;

    private ChessBoxController chessBoxController;

    public int valueDice;
    private bool isFinishDice;
    private bool isInitDice;

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
        diceData = new DiceData();
        diceData.summonPos = summonPos;
        diceData.diceObject = diceObject;
        diceData.diceRigidbody = diceRigibody;

        isFinishDice = false;
        isInitDice = false;
        isEndTurn = false;
    }

    void InitPlayer()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerController.InitPlayer();

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
                isFinishDice = false;
                isInitDice = true;
                diceControllerObject[0].Init(diceData);
                diceControllerObject[1].Init(diceData);
                diceControllerObject[0].Process();
                diceControllerObject[1].Process();
            }
        }
        if (isInitDice)
        {
            if (diceControllerObject[0].CheckStop() && diceControllerObject[1].CheckStop())
            {
                isFinishDice = true;
                valueDice = diceControllerObject[0].GetValueRoll() + diceControllerObject[1].GetValueRoll();

            }
        }

        if (isFinishDice)
        {
            playerController.Move(valueDice, turn);
            isFinishDice = false;
            isInitDice = false;
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
