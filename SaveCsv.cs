using UnityEngine;
using System.IO;

public static class SaveCsv
{
    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[10] {
        "Item",
        "Time",
        "GazeRay_x",
        "GazeRay_y",
        "GazeRay_z",
        "Direction_x",
        "Direction_y",
        "Direction_z",
        "Left_eye",
        "Right_eye"
        //how did you get head direction
    };

    // timestamp for whenever the header is included
    private static string timeStampHeader = "time stamp";

    public static void AppendToReport(string[] strings)
    {
        VerifyDirectory(); //check dir & file exist
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = ""; //starts empty
            for (int i = 0; i < reportHeaders.Length; i++) //loop through reportHeaders
            {
                if (finalString != "")
                {
                    finalString += reportSeparator; // gets the seperator added
                }
                finalString += reportSeparator[i];
            }
            finalString += reportSeparator + timeStampHeader; //adding the timestamp (might be redudant)
            sw.WriteLine(finalString);
        }
    }

    // helper methods below
    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    static string GetDirectoryPath()
    {
        return Application.dataPath + '/' + reportDirectoryName;
    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + '/' + reportFileName;
    }

    static string GetTimeStamp()
    { //might be redundant to Tobii.XR.time
        return System.DateTime.UtcNow.ToString();
    }
}

