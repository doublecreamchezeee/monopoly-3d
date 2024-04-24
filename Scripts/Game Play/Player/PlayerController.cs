using System;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] playerPrefab;
    public PlayerData[] playerData;
    public string[] namelist;
    public Transform summonPlace;
    private GameObject[] player;

    private int size;
    private GameObject currentPos;
    private GameObject targetPos;

    private ChessBoxController boxController;
    public TextMeshPro textBox;
    public TextMeshPro textCash;




    private void Start()
    {
        //size = player.Length;
        playerData = new PlayerData[size];
        for (int i = 0; i< size; i++)
        {
            playerData[i] = new PlayerData(namelist[i]);
        }
        boxController = gameObject.GetComponentInParent<ChessBoxController>(); 
    }

    public void InitPlayer(int size)
    {
        this.size = size;
        player = new GameObject[size];
        for (int i = 0; i< size; i++)
        {
            player[i] = Instantiate(playerPrefab[i], summonPlace, true);
        }
    }
    private int Rotate(int target)
    {
        int bonusRotation = (target + 1) / 11;
        if (bonusRotation == 0)
        {
            return 270;
        }
        else if (bonusRotation == 1)
        {
            return 360;
        }
        else if (bonusRotation == 2)
        {
            return 90;
        }
        return 180;
    }
    public void Move(int move, int numberPlayer) 
    {
        if (move == 0)
        {
            return;
        }
        
        currentPos = GameObject.Find(playerData[numberPlayer].currentBox.ToString());
        int current = int.Parse(currentPos.gameObject.name);
        int target = current + move;
        if (current == 0 || target >= 39)
        {
            playerData[numberPlayer].money += 200;
            if (current != 0)
                target -= 39;
        }
        playerData[numberPlayer].currentBox = target; 
        
        targetPos = GameObject.Find(target.ToString());
        //Debug.Log(target);
        player[numberPlayer].transform.position = targetPos.transform.position;
        int rotate = Rotate(target);
        float currentRotation = player[numberPlayer].transform.rotation.eulerAngles.y;
        //Debug.Log(rotate - currentRotation);

        player[numberPlayer].transform.Rotate(0.0f, rotate - currentRotation , 0.0f, Space.World);
        InformText(target, numberPlayer);

    }

    public void Buy(int numberPlayer)
    {
        currentPos = GameObject.Find(playerData[numberPlayer].currentBox.ToString());
        int current = int.Parse(currentPos.gameObject.name);
        Upgrade(boxController.chessBoxData[current], currentPos,numberPlayer);

        int price = boxController.chessBoxData[current].price;
        if (playerData[numberPlayer].money >= price)
        {
            playerData[numberPlayer].money -= price;
        }
        
        InformText(current, numberPlayer);
    }

    private void Upgrade(ChessBoxData chessBox, GameObject currentPos, int numberPlayer) 
    {
        Material material = new Material(currentPos.GetComponent<MeshRenderer>().material);
      
        if (chessBox.level == 0)
        {
            if (numberPlayer == 0)
            {
                material.color = new Color(221 / 255f, 160 / 255f, 221 / 255f);
                currentPos.GetComponent<MeshRenderer>().material = material;
            }
            else
            {
                material.color = new Color(165 / 255f, 42 / 255f, 42 / 255f);
                currentPos.GetComponent<MeshRenderer>().material = material;
            }
        }
    }

    private void InformText(int targetBox, int numberPlayer)
    {
        string formattedTextBox = $"Tên: {boxController.chessBoxData[targetBox].name}\n" +
            $"Giá mua: {boxController.chessBoxData[targetBox].price}\n" +
            $"Giá bán: {boxController.chessBoxData[targetBox].sellPrice}\n" +
            $"Giá thuê: {boxController.chessBoxData[targetBox].rent}\n";
        textBox.text = formattedTextBox;

        string formattedTextCash = $"Cash: {playerData[numberPlayer].money}";
        textCash.text = formattedTextCash;
    }

}
