using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationController : MonoBehaviour
{
    public Animator monsterAnimator;
    public AnimationClip monsterAnimation;

    private float timer;
    private float monsterAnimLength;

    private void Start()
    {
        timer = 0;
        monsterAnimLength = monsterAnimation.length - 0.5f;
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > monsterAnimLength)
        {
            monsterAnimator.CrossFade(monsterAnimation.name, 0.5f);
            timer = 0;
            print("worked");
        }
    }
}
