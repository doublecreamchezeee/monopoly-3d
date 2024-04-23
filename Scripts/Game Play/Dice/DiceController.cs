using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class DiceController
{
    private float DefaultForce;
    private float DefaultTorque;

    private GameObject diceInit;

    private int valueRoll;

    private void Roll()
    {
        Vector3 randomForce = new Vector3(Random.Range(-DefaultForce, DefaultForce), Random.Range(0, DefaultForce), Random.Range(-DefaultForce, DefaultForce));
        Vector3 randomTorque = new Vector3(Random.Range(-DefaultTorque, DefaultTorque), Random.Range(-DefaultTorque, DefaultTorque), Random.Range(-DefaultTorque, DefaultTorque));
        diceInit.GetComponent<Rigidbody>().AddForce(randomForce);
        diceInit.GetComponent<Rigidbody>().AddTorque(randomTorque);
    }

    public int GetValueRoll()
    {
        valueRoll = diceInit.GetComponent<Die_d6>().value;
        return valueRoll;
    }


    public void Init(DiceData diceData)
    {
        diceInit = GameObject.Instantiate(diceData.diceObject, diceData.summonPos);
        DefaultForce = diceData.DefaultForce;
        DefaultTorque = diceData.DefaultTorque;

    }

    public void Destroy()
    {
        GameObject.Destroy(diceInit);
    }

    public bool CheckQuantity()
    {
        bool check = true;
        if (GameObject.FindWithTag("Dice") != null)
        {
            check = false;
        }
        return check;
    }

    public bool CheckStop()
    {
        if (diceInit.GetComponent<Rigidbody>().velocity != Vector3.zero || diceInit.transform.position.y - 3 >= 1)
        {
            return false;
        }
        return true;
    }


    public void Process()
    {
        Roll();
    }
}
