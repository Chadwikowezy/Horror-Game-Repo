using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateLoader : MonoBehaviour
{
    #region variables
    public GameController gameController;

    private int count = 0;

    public GameObject fakeActorObj;

    #endregion

    #region Awake function call
    void Start ()
    {
        if(gameController == null)
        {
            gameController = FindObjectOfType<GameController>();
        }
        
        if(System.IO.File.Exists(Path.Combine(Application.persistentDataPath, "actors.json")))
        {
            CallLoaderSpawn();
        }
        else
        {
            CallCreateFakeLoader();
        }
	}
    #endregion

    #region create fake loader and call loader functions
    void CallCreateFakeLoader()
    {
        Instantiate(fakeActorObj, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void CallLoaderSpawn()
    {
        if(count < 1)
        {
            gameController.Loaded();
            count++;
            Actor loadedActor = FindObjectOfType<Actor>();
            if(loadedActor != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion
}
