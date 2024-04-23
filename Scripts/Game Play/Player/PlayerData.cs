using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string name;
    public int money;
    public int debt;
    public int currentBox;

    public PlayerData(string name)
    {
        this.name = name;
        money = 0;
        debt = 0;
        currentBox = 0;
    }
}
