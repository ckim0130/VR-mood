using System.Collections; //use array
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
// using Tobii.G2OM; - should still work 
using System.Diagnostics;

public class EyeTrack : MonoBehaviour
{
    public List<float> time = new List<float>();
    public List<bool> isvalidlist = new List<bool>();
    public List<Vector3> origin = new List<Vector3>(); //3d vetor
    public List<Vector3> direction = new List<Vector3>(); //3d vetor
    public List<Vector3> GazeDirection = new List<Vector3>();
    public List<bool> LeftEye = new List<bool>();
    public List<bool> RightEye = new List<bool>();
    //List of all the AOIs in the scene example 30;
    public bool test = false;

    public void getdata()
    {
        // Get eye tracking data in world space
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);
        // Add timestamp into time?
        // UnityEngine.Debug.Log("test" + eyeTrackingData.GazeRay.Origin);
        // Check if gaze ray is valid

        if (eyeTrackingData.GazeRay.IsValid)
        {
            var timestamp = eyeTrackingData.Timestamp;
            time.Add(timestamp);
            //System.Diagnostics.Debug.WriteLine("time");
            UnityEngine.Debug.Log(eyeTrackingData.GazeRay.Direction);
            // isvalidlist.Add(true). Don't necessarily have to add it?
            var rayOrigin = eyeTrackingData.GazeRay.Origin; // The origin of the gaze ray is a 3D point
            origin.Add(rayOrigin);
            var rayDirection = eyeTrackingData.GazeRay.Direction; // The direction of the gaze ray is a normalized direction vector
            direction.Add(rayDirection);

            var eyeTrackingLocal = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.Local);
            var isLeftEyeBlinking = eyeTrackingLocal.IsLeftEyeBlinking;
            LeftEye.Add(isLeftEyeBlinking);

            var isRightEyeBlinking = eyeTrackingLocal.IsRightEyeBlinking;
            RightEye.Add(isRightEyeBlinking);

            var eyesDirection = eyeTrackingLocal.GazeRay.Direction;
            GazeDirection.Add(eyesDirection);
            
            //for loop call each gameobject, go to their track at gaze function, and check if track at gaze is true, if they are not looking at anything imp, put X.
            //var result = time.Concat(origin).Concat(direction).Concat(LeftEye).Concat(RightEye).Concat(GazeDirection);
        }
    }

    // wait for one second and call the getdata()
    private IEnumerator SampleRate()
    {
        yield return new WaitForSeconds(0.5f);
        getdata();
        test = true;
    }

    // wait for one second and call another getdata
    private void Start()
    {
        getdata();
        SampleRate();
    }

    private void Update()
    {
        if (test == true)
        {
            test = false;
            SampleRate();
        }
    }
}
