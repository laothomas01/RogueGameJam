using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    //Animation States
    const string PLAYER_IDLE = "PlayerIdleShootAnimation";
    const string PLAYER_MOVEMENT = "PlayerMovementShoot";
    const string PLAYER_DEATH = "PlayerDeathAnimation";

    private Animator animator;
    private string currentState;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;
        //play the animation
        animator.Play(newState);
        //reassign the current state
        currentState = newState;
    }

}
