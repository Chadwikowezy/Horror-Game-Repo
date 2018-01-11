using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject prefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {          
            Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
    }

}
