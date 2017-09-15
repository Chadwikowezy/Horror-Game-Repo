using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator anim;


	void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	
    public void SetAnimState(string animName)
    {
        anim.SetInteger("idle", 0);
        anim.SetInteger("crouch", 0);
        anim.SetInteger(animName, 1);
    }
}
