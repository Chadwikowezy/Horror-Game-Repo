using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPCS_Camera : MonoBehaviour
{
    public Transform targetCamPos;
    public Transform target;

    public List<Transform> panRotTransforms = new List<Transform>();

    public float moveSpeed;
    public float rotSpeed;

    private Quaternion camRotation;

    public GameObject phoneObj;
    private OPCS_Player player;
    public OPCS_AudioManager audioManager;
    public AudioSource audioSource;

    void Start()
    {
        player = FindObjectOfType<OPCS_Player>();
        player.myNav.speed = 0;
        audioManager = FindObjectOfType<OPCS_AudioManager>();

        StartCoroutine(ReadPhoneDelay());
        audioManager = FindObjectOfType<OPCS_AudioManager>();
    }

    IEnumerator ReadPhoneDelay()
    {
        audioSource.clip = audioManager.audioclip_01;
        audioSource.Play(); 
        
        yield return new WaitForSeconds(2f);
        phoneObj.SetActive(true);

        yield return new WaitForSeconds(30f);
        phoneObj.GetComponent<Animator>().Play("Phone_FlyOut");
        yield return new WaitForSeconds(.5f);
        phoneObj.SetActive(false);
        player.myNav.speed = 2;
    }

    void FixedUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, targetCamPos.position, moveSpeed * 0.1f);

        RotateCam();
    }
	
	void RotateCam()
    {
        if(target == null)
        {
            camRotation = Quaternion.Slerp(transform.rotation, targetCamPos.rotation, rotSpeed * 0.1f);
        }
        else
        {
            Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);
            camRotation = Quaternion.Slerp(transform.rotation, lookRot, rotSpeed * 0.1f);
        }
        transform.localRotation = camRotation;
    }
}
