using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFogCheck : MonoBehaviour
{
    private InvisibleFloorPuzzleManager invisibleFloorPuzzleManager;
    public GameObject fogEffectLeft;
    public GameObject fogEffectRight;

    void OnTriggerEnter(Collider other)
    {
        invisibleFloorPuzzleManager = FindObjectOfType<InvisibleFloorPuzzleManager>();
        if (invisibleFloorPuzzleManager.hasFallen == true)
        {
            invisibleFloorPuzzleManager.beginFogFollow = true;
            invisibleFloorPuzzleManager.hasFallen = false;

            fogEffectLeft.SetActive(false);
            fogEffectRight.SetActive(false);
        }
        else
        {
            invisibleFloorPuzzleManager.beginFogFollow = false;
            invisibleFloorPuzzleManager.hasFallen = true;

            fogEffectLeft.SetActive(true);
            fogEffectRight.SetActive(true);
        }
    }
}
