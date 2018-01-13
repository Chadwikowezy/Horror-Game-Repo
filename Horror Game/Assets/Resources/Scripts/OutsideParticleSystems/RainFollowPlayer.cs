using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollowPlayer : MonoBehaviour
{
    public GameObject rainEffect;
    private PlayerMotor player;
    private Actor actor;
    public Vector3 followVector;

    void Start()
    {
        player = FindObjectOfType<PlayerMotor>();
    }

    void Update()
    {
        CheckIfCanFollow();
    }

    public void CheckIfCanFollow()
    {
        actor = FindObjectOfType<Actor>();

        if (actor.data.masionPuzzle_F2_01 == true)
        {
            rainEffect.SetActive(true);

            followVector = new Vector3(player.transform.position.x, player.transform.position.y + 7.1f, player.transform.position.z);
            //transform.position = followVector;       
            transform.position = Vector3.Lerp(transform.position, followVector, Time.fixedDeltaTime);
        }
        else
        {
            rainEffect.SetActive(false);
        }
    }
}
