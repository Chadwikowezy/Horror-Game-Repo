using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard_CollectObject : MonoBehaviour
{
    public bool compass;
    public bool knife;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (compass)
            {
                //activate compass collect button
            }
            else
            {
                //activate knife collect button
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (compass)
            {
                //de-activate compass collect button
            }
            else
            {
                //de-activate knife collect button
            }
        }
    }
}
