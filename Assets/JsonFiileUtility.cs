using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class JsonFiileUtility 
{
    

    public static string LoadJsonFromFile (string path, bool isResource)
    {
        if (isResource)
        {
            return LoadJsonAsResource(path);

        }else
        {
            return LoadJsonAsExternalResource(path);
        }
    }

    public static string  LoadJsonAsResource (string path)
    {
        string jsonFilePath = path.Replace(".json", "");
        TextAsset loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
        return loadedJsonfile.text;

    }

    public static string LoadJsonAsExternalResource (string path)
    {
        path = Application.persistentDataPath + "/" + path;
        if (!File.Exists(path))
        {
            return null;
        }
        StreamReader reader = new StreamReader(path);
        string response = "";
        while (!reader.EndOfStream)
        {
            response += reader.ReadLine();
        }
        return response;
    }


    public static void WriteJsonToExternalResource(string path,string content)
    {
        path = Application.persistentDataPath + "/" + path;
        FileStream stream = File.Create(path);
        byte[] contentBytes = new UTF8Encoding(true).GetBytes(content);
        stream.Write(contentBytes, 0, contentBytes.Length);
        Debug.Log(Application.persistentDataPath);

    }

  
    


   

}
