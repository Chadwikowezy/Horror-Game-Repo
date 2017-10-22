using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    #region variables
    public static ActorContainer actorContainer = new ActorContainer();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;
    #endregion

    #region static function call for saving and loading
    public static void Load(string path)
    {
        actorContainer = LoadActors(path);

        foreach(ActorData data in actorContainer.actors)
        {
            GameController.GenerateActor(data, GameController.loaderPath, new Vector3(0, 0, 0), Quaternion.identity);
        }
        OnLoaded();

        ClearActorList();
    }
    public static void Save(string path, ActorContainer actors)
    {
        OnBeforeSave();

        SaveActors(path, actors);

        ClearActorList();
    }
    #endregion

    #region clearing and adding actor data from actor container class list
    public static void AddActorData(ActorData data)
    {
        actorContainer.actors.Add(data);
    }

    public static void ClearActorList()
    {
        actorContainer.actors.Clear();
    }
    #endregion

    #region static ActorContainer LoadActors function call and SaveActors function call
    private static ActorContainer LoadActors(string path)
    {
        string json = File.ReadAllText(path);

        return JsonUtility.FromJson<ActorContainer>(json);
    }

    private static void SaveActors(string path, ActorContainer actors)
    {
        string json = JsonUtility.ToJson(actors);

        StreamWriter sw = File.CreateText(path);
        sw.Close();

        File.WriteAllText(path, json);
    }
    #endregion
}
