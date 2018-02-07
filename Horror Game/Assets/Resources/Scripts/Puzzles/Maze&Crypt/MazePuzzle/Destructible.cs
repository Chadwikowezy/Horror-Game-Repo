using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject inputObj;
    [SerializeField]
    private GameObject inputText;
    private ToolsManager toolManager;



    IEnumerator FunctionDelay()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        toolManager = FindObjectOfType<ToolsManager>();
    }

    public void Break()
    {
        if(toolManager.hasCrowbar == true)
        {
            PlayAudio();           
            Instantiate(prefab, transform.position, Quaternion.identity);
            StartCoroutine("FunctionDelay");           
            inputObj.SetActive(false);
            inputText.SetActive(false);
        }
        
    } 

    public void PlayAudio()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }

}
