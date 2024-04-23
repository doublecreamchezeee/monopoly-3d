using UnityEngine;

public class DiceData : MonoBehaviour
{
    // dice reference 
    public GameObject diceObject;
    // position in game that dice will be init 
    public Transform summonPos;
    
    public Rigidbody diceRigidbody;

    public bool isFinishDice;
    public bool isInitDice;

    public float DefaultForce = 2000;
    public float DefaultTorque = 100000;

    //public DiceData(DiceData diceData)
    //{
    //    this.summonPos = diceData.summonPos;
    //    this.diceObject = diceData.diceObject;
    //    this.diceRigidbody = diceData.diceRigidbody;
    //}

    public DiceData(
            Transform summonPos, 
            Rigidbody diceRigidbody, 
            GameObject diceObject, 
            bool isInitDice, 
            bool isFinishDice)
    {
        this.summonPos = summonPos;
        this.diceObject = diceObject;
        this.diceRigidbody=diceRigidbody;
        this.isFinishDice = isFinishDice;
        this.isInitDice = isInitDice;
    }

}
