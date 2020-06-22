using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class CSVReader
{
    private static List<KeyValuePair<string, int>> scoreList;

    private static void LoadCSV(string path)
    {
        scoreList = new List<KeyValuePair<string, int>>();

        string fileData = File.ReadAllText(path);
        fileData.Replace("\r", "");
        string[] lines = fileData.Split('\n');


        for (int j = 0; j < lines.Length - 1; j++)
        {
            string[] lineData = (lines[j].Trim()).Split(',');
            int x;
            if (int.TryParse(lineData[1], out x))
                scoreList.Add(new KeyValuePair<string, int>(lineData[0].ToString(), x));
        }
        scoreList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
    }

    public static List<KeyValuePair<string, int>> GetScoreFromCSV(string path)
    {
        LoadCSV(path);
        return scoreList;
    }

    public static void AddScoreToCSV(string filePath, string name, int score)
    {
        StreamWriter outStream = System.IO.File.AppendText(filePath);

        outStream.WriteLine(name + "," + score.ToString());

        outStream.Close();
    }

}
