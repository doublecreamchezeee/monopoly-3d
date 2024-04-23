using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoxData
{
    public int orderBox;
    public string name;
    public int level;
    public int price;
    public int rent;
    public int sellPrice;

    public ChessBoxData(int a, string b, int c, int d, int e, int f)
    {
        orderBox = a;
        name = b;   
        level = c;
        price = d;
        rent = e;
        sellPrice = f;
    }
}
