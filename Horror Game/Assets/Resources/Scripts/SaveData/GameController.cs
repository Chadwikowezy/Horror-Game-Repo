using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public const string loaderPath = "Prefabs/Loader";

    private static string dataPath = string.Empty;

    //public object JsonConvert { get; private set; }

	void Awake ()
    {
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
        Debug.Log(dataPath);
	}
	
	public static Actor GenerateActor(string path, Vector3 pos, Quaternion rotation)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject actorObj = Instantiate(prefab, pos, rotation) as GameObject;

        Actor actor = actorObj.GetComponent<Actor>() ?? actorObj.AddComponent<Actor>();

        return actor;
    }

    public static Actor GenerateActor(ActorData data, string path, Vector3 pos, Quaternion rotation)
    {
        Actor actor = GenerateActor(path, pos, rotation);

        actor.data = data;

        return actor;
    }

    public void Save()
    {
        SaveData.Save(dataPath, SaveData.actorContainer);
    }
    public void Loaded()
    {
        SaveData.Load(dataPath);
    }
}
