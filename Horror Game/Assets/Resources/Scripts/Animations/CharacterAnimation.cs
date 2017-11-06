using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator leftArm;
    public Animator rightArm;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        AnimateLeftArm();
    }

    void AnimateLeftArm()
    {
        leftArm.SetFloat("Rigidbody Velocity", _rb.velocity.magnitude);
    }
}
