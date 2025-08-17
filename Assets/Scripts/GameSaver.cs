using System.IO;
using System.Text;
using System;
using Newtonsoft.Json;
using UnityEngine;

public static class GameSaver
{
    public static string SavePath = Application.persistentDataPath + "/save/";

    public static void Save<T>(T obj) where T : class
    {
        var saveFilePath = GetFilePath(typeof(T).Name);
        var json = JsonConvert.SerializeObject(obj);

        if (!Directory.Exists(Path.GetDirectoryName(saveFilePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(saveFilePath))
            {
                writer.Write(json);
            }
        }
        catch
        {

        }
        Debug.Log("Save data to: " + saveFilePath);

    }

    public static bool TryLoad<T>(out T obj) where T : class
    {
        var path = GetFilePath(typeof(T).Name);

        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }

        StringBuilder textToLoad = new();

        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                        continue;

                    textToLoad.AppendLine(line);
                }
            }
            obj = JsonConvert.DeserializeObject<T>(textToLoad.ToString());
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError("error " + ex.Message);
            obj = default(T);
            Debug.LogError("CANT LOAD CLASS AT " + path);
            return false;
        }
    }

    private static string GetFilePath<T>(T obj)
    {
        return Path.Combine(SavePath, obj.ToString() + ".json");
    }
}