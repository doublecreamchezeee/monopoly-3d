using UnityEngine;
using System.IO;

public class ChessBoxController : MonoBehaviour
{
    public GameObject[] chessBox;
    public ChessBoxData[] chessBoxData;

    private void Start()
    {
        string filePath = @"D:\unity\monopoly\Assets\Scripts\Game Play\ChessBox\DataChessBox.txt";

        chessBoxData = new ChessBoxData[40];

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == chessBoxData.Length)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] dataLine = lines[i].Split(',');

                    // Sử dụng constructor để khởi tạo đối tượng ChessBoxData và gán nó vào mảng chessBoxData
                    chessBoxData[i] = new ChessBoxData(
                        int.Parse(dataLine[0]),
                        dataLine[1],
                        int.Parse(dataLine[2]),
                        int.Parse(dataLine[3]),
                        int.Parse(dataLine[4]),
                        int.Parse(dataLine[5])
                    );
                }
            }
        }

    }
}

        
