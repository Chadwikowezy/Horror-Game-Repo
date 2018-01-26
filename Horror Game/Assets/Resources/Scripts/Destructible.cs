using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //if player.crowbar = true  
            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
    }

}
