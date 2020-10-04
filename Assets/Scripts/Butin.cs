using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butin : MonoBehaviour
{


    private Animator animator;
    public AnimationClip[] animations = new AnimationClip[2];

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void setIdle()
    {
        AnimatorOverrideController aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
        var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        foreach (var a in aoc.animationClips)
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, animations[0]));
        aoc.ApplyOverrides(anims);
        animator.runtimeAnimatorController = aoc;
        
    }

    public void setAttack()
    {
        AnimatorOverrideController aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
        var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        foreach (var a in aoc.animationClips)
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, animations[1]));
        aoc.ApplyOverrides(anims);
        animator.runtimeAnimatorController = aoc;
    }
}
