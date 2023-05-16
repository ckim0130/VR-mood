using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyTool : MonoBehaviour
{
    //Remove
    public void checker() // checks the length of the study. 
    {
        for (int i = 0; i < this.GetComponent<EyeTrack>().time.Count; i++) // go until the end of time
        { // do DEV_AppendToReport
        }

    }
// Not necessary
    //public void getresult()
    //{
    //    //[MenuItem("My Tools/Aded to Report %F1")]
    //    DEV_AppendToReport();
    //}

    //[MenuItem("My Tools/Aded to Report %F1")] //Adding rows to the report

    public List<float> time = new List<float>();

    public void DEV_AppendToReport()
    {
        SaveCsv.AppendToReport(
            // Add the variables 
            time = GetComponent<EyeTrack>().time.ToString()
            //change to string?
            );
        EditorApplication.Beep();
        Debug.Log("Report updated successfully!");
    }

    //[MenuItem("My Tools/Reset to Report %F2")]
    static void DEV_ResetReport()
    {
        SaveCsv.CreateReport();
        Debug.Log("Report has been reset!");
    }
}

//reference appendtoreport(new string[10])
//         write all the variables. Reference the index number. 
//         call another function that will write the getresult
//    


Gameobject.Find("Origin").getcomponent...
