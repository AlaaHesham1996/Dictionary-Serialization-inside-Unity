using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileTest : MonoBehaviour
{
    [System.Serializable]

    public struct Keypoint
    {
        public string name;
        public List<float> timestamp;
        public List<Vector3> position;
        public List<Quaternion> rotation;
        

    }
    [System.Serializable]
    public struct BodyMarkers
    {
        public List<Keypoint> keypoints;
    }

    Dictionary<string, Keypoint> dicKeypoints;

    // Start is called before the first frame update
    void Start()


    {   // Adding information about Right Shoullder keypoints manually 
        //List<Vector3> rsPos = new List<Vector3>();
        //rsPos.Add(new Vector3(1, 2, 3));
        //List<Quaternion> rsRot = new List<Quaternion>();
        //rsRot.Add(new Quaternion(4, 5, 6, 7));
        //List<float> rsTimestamp = new List<float>();
        //rsTimestamp.Add(0.0f);

        //// Adding information about Left Leg Keypoint manually
        //List<Vector3> llPos = new List<Vector3>();
        //llPos.Add(new Vector3(8, 9, 10));
        //List<Quaternion> llRot = new List<Quaternion>();
        //llRot.Add(new Quaternion(11, 12, 13, 14));
        //List<float> llTimestamp = new List<float>();
        //llTimestamp.Add(0.0f);


        dicKeypoints = new Dictionary<string, Keypoint>();

        //dicKeypoints.Add("rightshoulder", new Keypoint() { name = "rightshoulder", timestamp = rsTimestamp, position = rsPos, rotation = rsRot });
        //dicKeypoints.Add("leftleg", new Keypoint() { name = "leftleg", timestamp = llTimestamp, position = llPos, rotation = llRot });

        //SaveKeypoints();
        LoadKeypoints();
        List<string> keypointsNames = new List<string>(dicKeypoints.Keys);
        foreach (string theName in keypointsNames)
        {
            Debug.Log("Keypoint ID: " + dicKeypoints[theName].name + "   Timestamp:  " + dicKeypoints[theName].timestamp[0].ToString());
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadKeypoints()
    {
        BodyMarkers tempCollection = JsonUtility.FromJson<BodyMarkers>(JsonFiileUtility.LoadJsonFromFile("KeyPointsCollection.json", false));
        foreach (Keypoint marker in tempCollection.keypoints)
        {
           dicKeypoints.Add(marker.name, marker);
        }
    }

    public void SaveKeypoints()
    {
        List<string> keypointsnames = new List<string>(dicKeypoints.Keys);
        List<Keypoint> toSaveCollection = new List<Keypoint>();
        foreach (string dicKey in keypointsnames)
        {
            toSaveCollection.Add(dicKeypoints[dicKey]);
        }
        BodyMarkers saveCollection = new BodyMarkers() { keypoints = toSaveCollection };
        string jsonString = JsonUtility.ToJson(saveCollection,true);
        JsonFiileUtility.WriteJsonToExternalResource("KeyPointsCollection.json", jsonString);
        
                                      

    }
  
}
