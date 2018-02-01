using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPCS_RainManager : MonoBehaviour
{
    public List<GameObject> rainParticleSystems = new List<GameObject>();
    private OPCS_Player player;
	
	void Start ()
    {
        player = FindObjectOfType<OPCS_Player>();
    }

    void LateUpdate()
    {
        DisableRainOnDist();
    }

    void DisableRainOnDist()
    {
        foreach(GameObject rainSys in rainParticleSystems)
        {
            if(Vector3.Distance(rainSys.transform.position, player.transform.position) > 35)
            {
                rainSys.SetActive(false);
            }
            else
            {
                rainSys.SetActive(true);
            }
        }
    }
}
