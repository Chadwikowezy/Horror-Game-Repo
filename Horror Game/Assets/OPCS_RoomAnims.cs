using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPCS_RoomAnims : MonoBehaviour
{
    public Transform stationaryPos;
    public Transform target;

    public List<Transform> panRotTransforms = new List<Transform>();

    public float moveSpeed;
    public float rotSpeed;

    private Quaternion camRotation;

    public GameObject phoneObj;

    void Start()
    {
        StartCoroutine(OpeningCameraPanel());
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, stationaryPos.position, moveSpeed * 0.1f);

        RotateCam();
    }

    void RotateCam()
    {
        if (target == null)
        {
            camRotation = Quaternion.Slerp(transform.rotation, stationaryPos.rotation, rotSpeed * 0.1f);
        }
        else
        {
            Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);
            camRotation = Quaternion.Slerp(transform.rotation, lookRot, rotSpeed * 0.1f);
        }
        transform.localRotation = camRotation;
    }

    IEnumerator OpeningCameraPanel()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < panRotTransforms.Count; i++)
        {
            if(panRotTransforms[i] != panRotTransforms[3])
            {
                yield return new WaitForSeconds(1.5f);
                target = panRotTransforms[i].transform;
            }
            
            if(panRotTransforms[i] == panRotTransforms[3])
            {
                phoneObj.SetActive(true);
                target = panRotTransforms[i].transform;
                phoneObj.GetComponentInChildren<Animator>().Play("Phone_FlyIn");
                yield return new WaitForSeconds(5f);
            }
        }

    }
}
