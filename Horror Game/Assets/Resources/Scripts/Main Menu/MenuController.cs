using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [Header("Flickering Light")]
    public Light flickeringLight;
    public int minNumOfFlickers;
    public int maxNumOfFlickers;
    public float minWaitTime;
    public float maxWaitTime;

    private void Start()
    {
        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        int numOfFlickers;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            numOfFlickers = Random.Range(minNumOfFlickers, maxNumOfFlickers);

            for (int i = 0; i < numOfFlickers; i++)
            {
                yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));

                flickeringLight.enabled = !flickeringLight.enabled;
            }
        }
    }
}
