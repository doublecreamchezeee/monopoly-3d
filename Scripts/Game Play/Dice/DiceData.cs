using UnityEngine;

public class DiceData : MonoBehaviour
{
    public GameObject diceObject;
    public Transform summonPos;
    public Rigidbody diceRigidbody;

    public float DefaultForce = 2000;
    public float DefaultTorque = 100000;

    public DiceData(DiceData diceData)
    {
        this.summonPos = diceData.summonPos;
        this.diceObject = diceData.diceObject;
        this.diceRigidbody = diceData.diceRigidbody;
    }

    public DiceData()
    {

    }

}
