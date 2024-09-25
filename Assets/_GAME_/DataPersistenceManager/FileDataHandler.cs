using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler
{
    private string saveFile = "";

    public FileDataHandler(string fileDir, string fileName)
    {
        this.saveFile = Path.Combine(fileDir, fileName);
    }

    public GameData Load()
    {
        GameData data = null;
        if (File.Exists(saveFile))
        {
            try
            {
                data = JsonUtility.FromJson<GameData>(File.ReadAllText(saveFile));
            }
            catch (Exception e)
            {
                Debug.LogError("Error while loading data from file: " + saveFile + "\n" + e);
            }
        }
        return data;
    }

    public void Save(GameData data)
    {
        try
        {
            //create file
            Directory.CreateDirectory(Path.GetDirectoryName(saveFile));

            string toSave = JsonUtility.ToJson(data, true);

            File.WriteAllText(saveFile, toSave);
            Debug.Log("Written data to " + Application.persistentDataPath);
        }
        catch (Exception e)
        {
            Debug.LogError("Error while saving data to file: " + saveFile + "\n" + e);
        }
    }
}
